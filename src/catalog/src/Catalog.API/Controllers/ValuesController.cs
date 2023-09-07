using Catalog.API.Application.Commands.ValueCommands;
using Catalog.API.Application.IntegrationEvents.Events;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Infrastructure.Services;
using EventBus.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPublishEvent _eventBus;
        private readonly IIdentityService _identityService;

        public ValuesController(IPublishEvent eventBus,
            IIdentityService identityService)
        {
            _eventBus = eventBus;
            _identityService = identityService;
        }

        [Route("version")]
        [HttpGet]
        public IEnumerable<string> Index()
        {
            return new string[] { "Catalog Service", "Version 1.0" };
        }

        [Route("publish-event")]
        [HttpPost]
        public async Task<IActionResult> PublishEvent([FromBody] OrderCommand command)
        {
            var integrationEvent = new OrderIntegrationEvent()
            {
                CustomerId = command.CustomerId,
                OrderId = command.OrderId,
                ProductId = command.ProductId,
                Quantity = command.Quantity,
                Status = command.Status
            };
            await _eventBus.Publish(integrationEvent);
            var result = Response<ResponseDefault>.Success("event has been delivered successfully");
            return Ok(result);
        }

        [Authorize(Policy = "User")]
        [Route("only-user")]
        [HttpGet]
        public IActionResult OnlyUser()
        {
            var user = _identityService.GetIdentityUser();
            return Ok(new { id = 1, user });
        }
    }
}