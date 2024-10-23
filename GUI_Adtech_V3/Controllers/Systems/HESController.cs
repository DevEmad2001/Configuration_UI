using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech.Controllers.Systems
{
    public class HESController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MeterInstallation()
        {
            return View();
        }

        public IActionResult DailyReading()
        {
            return View();
        }

        public IActionResult ControlService()
        {
            return View();
        }

        public IActionResult DataService()
        {
            return View();
        }
    }
}
