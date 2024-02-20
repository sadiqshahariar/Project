using Microsoft.AspNetCore.Mvc;

namespace FirstWebProject.Controllers
{
    public class DeshboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
