using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}