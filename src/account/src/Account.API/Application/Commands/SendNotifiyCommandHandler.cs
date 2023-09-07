using Account.API.Infrastructure.ResponseGeneric;
using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Account.API.Application.Commands
{
    public class SendNotifiyCommandHandler : IRequestHandler<SendNotifiyCommand, Response<ResponseDefault>>
    {
        private readonly ProducerConfig _kafkaConfig;
        private readonly KafkaSettings _settings;
        public SendNotifiyCommandHandler(ProducerConfig kafkaConfig, IOptions<KafkaSettings> options)
        {
            _kafkaConfig = kafkaConfig ?? throw new ArgumentNullException(nameof(kafkaConfig));
            _settings = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<Response<ResponseDefault>> Handle(SendNotifiyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using (var producer = new ProducerBuilder<string, string>(_kafkaConfig).Build())
                {
                    var result = await producer.ProduceAsync
                    (_settings.PublishTopic, new Message<string, string>
                    {
                        Key = request.EventId,
                        Value = JsonConvert.SerializeObject(request.EventData)
                    });

                    Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return Response<ResponseDefault>.Success();
        }
    }
}
