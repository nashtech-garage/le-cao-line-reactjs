using EventBus.Events;

namespace Notification.API.Application.IntegrationEvents.Events
{
    public record LoginNotifyIntegrationEvent : IntegrationEvent
    {
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string? UserIp { get; set; }
    }
}
