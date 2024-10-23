using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech.Controllers.Systems
{
    public class SCADAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NetwrokMeter()
        {
            return View();
        }
    }
}
