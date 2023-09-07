using EventBus.Events;

namespace Catalog.API.Application.IntegrationEvents.Events
{
    public record OrderSuccessIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; set; }
    }
}