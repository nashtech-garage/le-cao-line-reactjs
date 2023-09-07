 using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
