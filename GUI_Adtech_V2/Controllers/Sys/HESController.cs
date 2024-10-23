using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech_V2.Controllers.Sys
{
    public class HESController : Controller
    {

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
