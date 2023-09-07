using Account.API.Application.Commands;
using Account.API.Infrastructure.Services;
using Account.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public AccountsController(IIdentityService identityService, IMediator mediator)
        {
            _identityService = identityService;
            _mediator = mediator;
        }


        // GET: api/<AccountsController>
        [Authorize(Policy = "user")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountsController>/5
        [Authorize(Policy = "user")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountsController>
        [Authorize(Policy = "admin")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountsController>/5
        [Authorize(Policy = "admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [Authorize(Policy = "admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command) {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (result.State)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost] 
        [Route("Login")]
        public async Task<IActionResult> GenToken([FromBody] LoginCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (result.State)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (result.State)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
