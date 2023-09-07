using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("version")]
        public IActionResult Get()
        {
            return Ok(new { version = "1.0" });
        }
    }
}
