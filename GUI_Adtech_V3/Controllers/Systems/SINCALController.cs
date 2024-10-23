using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech.Controllers.Systems
{
    public class SINCALController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Feeders()
        {
            return View();
        }
        public IActionResult Transformers()
        {
            return View();
        }
    }
}
