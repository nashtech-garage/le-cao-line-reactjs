using Confluent.Kafka;
using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventBus.EventBusServiceBus
{
    public class KafkaPublishEvent : IPublishEvent
    {
        private readonly IProducer<string, byte[]> _producer;
        private readonly string _topic;
        public KafkaPublishEvent(
            string topic,
            IProducer<string, byte[]> producer
            )
        {
            _topic = topic;
            _producer = producer;
        }
        public async Task Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            var jsonMessage = JsonSerializer.Serialize(@event, @event.GetType());
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var message = new Message<string, byte[]>
            {
                Value = body,
                Key = eventName,
                Timestamp = Timestamp.Default
            };

            await _producer.ProduceAsync(_topic, message);
        }
    }
}
