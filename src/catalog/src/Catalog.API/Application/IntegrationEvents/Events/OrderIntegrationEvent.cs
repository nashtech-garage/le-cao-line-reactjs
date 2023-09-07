using EventBus.Events;

namespace Catalog.API.Application.IntegrationEvents.Events
{
    public record OrderIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}