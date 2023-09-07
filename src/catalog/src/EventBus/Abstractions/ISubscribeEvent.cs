using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface ISubscribeEvent
    {
        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        Task StartBasicConsume(CancellationToken stoppingToken = default);
    }
}