using Autofac;
using Confluent.Kafka;
using EventBus.Abstractions;
using EventBus.Events;
using System.Text.Json;

namespace EventBus.EventBusServiceBus
{
    public class KafkaSubscribeEvent : ISubscribeEvent
    {        
        private readonly IEventBusSubscriptionsManager _subsManager;
        const string AUTOFAC_SCOPE_NAME = "event_bus";
        private readonly ConsumerConfig _config;
        private readonly string _topic;

        private readonly ILifetimeScope _autofac;
        public KafkaSubscribeEvent(IEventBusSubscriptionsManager subsManager, 
            ILifetimeScope autofac, 
            ConsumerConfig config, 
            string topic)
        {
            _subsManager = subsManager;
            _autofac = autofac;
            _config = config;
            _topic = topic;
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            _subsManager.AddSubscription<T, TH>();
        }

        public async Task StartBasicConsume(CancellationToken stoppingToken = default)
        {
            try
            {
                using (var consumerBuilder = new ConsumerBuilder<string, string>(_config).Build())
                {
                    consumerBuilder.Subscribe(_topic);
                    try
                    {
                        while (!stoppingToken.IsCancellationRequested)
                        {
                            var consumer = consumerBuilder.Consume(stoppingToken);
                            if (consumer.Message.Key != null)
                            {
                                var eventName = consumer.Message.Key.ToString();

                                if (string.IsNullOrEmpty(eventName))
                                    continue;

                                await ProcessEvent(eventName, consumer.Message.Value);    
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public async Task ProcessEvent(string eventName, string message)
        {
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                using var scope = _autofac.BeginLifetimeScope(AUTOFAC_SCOPE_NAME);
                var subscriptions = _subsManager.GetHandlersForEvent(eventName);
                foreach (var subscription in subscriptions)
                {
                    var handler = scope.ResolveOptional(subscription.HandlerType);
                    if (handler == null) continue;
                    var eventType = _subsManager.GetEventTypeByName(eventName);
                    var integrationEvent = JsonSerializer.Deserialize(message, eventType, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                    await Task.Yield();
                    await ((Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent }));
                }
            }
        }
    }
}
