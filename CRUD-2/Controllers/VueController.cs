using Microsoft.AspNetCore.Mvc;

namespace CRUD_2.Controllers
{
    public class VueController : Controller
    {
        public IActionResult Index()
        {
            return File("~/dist/index.html", "text/html");
        }
    }
}
