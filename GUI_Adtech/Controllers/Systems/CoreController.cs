using GUI_Adtech.Models;
using GUI_Adtech.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GUI_Adtech.Controllers.Systems
{
    public class CoreController : Controller
    {
        private readonly IConfigRepository _configRepository;

        public CoreController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DatabaseConfig()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveConfig(AdtechConfig config)
        {
            if (ModelState.IsValid)
            {
                // تتبع البيانات المدخلة
                Console.WriteLine($"ParameterName: {config.ParameterName}, ParameterValue: {config.ParameterValue}, ComponentID: {config.ComponentID}");

                config.ModifiesDate = DateTime.Now; // تعيين تاريخ التعديل
                await _configRepository.AddConfigAsync(config);
                ViewBag.Message = "Configuration saved successfully!";
                return View("DatabaseConfig", config);
            }
            return View("DatabaseConfig", config);
        }


        public IActionResult FolderStructure()
        {
            return View();
        }

        public IActionResult SFTPConnector()
        {
            return View();
        }

        public IActionResult XMLValidation()
        {
            return View();
        }
    }
}
