using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IPublishEvent
    {
        Task Publish(IntegrationEvent @event);
    }
}