using Catalog.API.Application.IntegrationEvents.Events;
using EventBus.Abstractions;

namespace Catalog.API.Application.IntegrationEvents.EventHandling
{
    public class OrderSuccessIntegrationEventHandler : IIntegrationEventHandler<OrderSuccessIntegrationEvent>
    {
        private readonly ILogger _logger;

        public OrderSuccessIntegrationEventHandler(ILogger<OrderSuccessIntegrationEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(OrderSuccessIntegrationEvent @event)
        {
            _logger.LogInformation("Receiver event {0}", @event);
            await Task.CompletedTask;
        }
    }
}