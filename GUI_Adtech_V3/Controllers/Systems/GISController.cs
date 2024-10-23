using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech.Controllers.Systems
{
    public class GISController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GISUDA()
        {
            return View();
        }
        public IActionResult NetworkGISNode()
        {
            return View();
        }
    }
}
