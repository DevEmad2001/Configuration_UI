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



        //[HttpPost]
        //public async Task<IActionResult> SaveConfig(string serverPath, string portNumber, string username, string password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // حفظ Server Path
        //        var configServerPath = new AdtechConfig
        //        {
        //            ParameterName = "Server Path", // اسم الحقل
        //            ParameterValue = serverPath, // القيمة المدخلة من المستخدم
        //            ModifiesDate = DateTime.Now // الوقت الحالي
        //        };
        //        await _configRepository.AddConfigAsync(configServerPath);

        //        // حفظ Port Number
        //        var configPortNumber = new AdtechConfig
        //        {
        //            ParameterName = "Port Number",
        //            ParameterValue = portNumber,
        //            ModifiesDate = DateTime.Now
        //        };
        //        await _configRepository.AddConfigAsync(configPortNumber);

        //        // حفظ Username
        //        var configUsername = new AdtechConfig
        //        {
        //            ParameterName = "Username",
        //            ParameterValue = username,
        //            ModifiesDate = DateTime.Now
        //        };
        //        await _configRepository.AddConfigAsync(configUsername);

        //        // حفظ Password
        //        var configPassword = new AdtechConfig
        //        {
        //            ParameterName = "Password",
        //            ParameterValue = password,
        //            ModifiesDate = DateTime.Now
        //        };
        //        await _configRepository.AddConfigAsync(configPassword);

        //        // عرض رسالة نجاح
        //        ViewBag.Message = "Configuration saved successfully!";
        //        return View("DatabaseConfig");
        //    }

        //    return View("DatabaseConfig");
        //}

        [HttpPost]
        public async Task<IActionResult> SaveConfig(string serverPath, string portNumber, string username, string password)
        {
            if (ModelState.IsValid)
            {
                // تحديث أو إضافة ServerPath
                var configServerPath = await _configRepository.GetConfigByParameterNameAsync("ServerPath");
                if (configServerPath != null)
                {
                    configServerPath.ParameterValue = serverPath;
                    configServerPath.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configServerPath);
                }

                // تحديث أو إضافة PortNumber
                var configPortNumber = await _configRepository.GetConfigByParameterNameAsync("PortNumber");
                if (configPortNumber != null)
                {
                    configPortNumber.ParameterValue = portNumber;
                    configPortNumber.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configPortNumber);
                }

                // تحديث أو إضافة Username
                var configUsername = await _configRepository.GetConfigByParameterNameAsync("Username");
                if (configUsername != null)
                {
                    configUsername.ParameterValue = username;
                    configUsername.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configUsername);
                }

                // تحديث أو إضافة Password
                var configPassword = await _configRepository.GetConfigByParameterNameAsync("Password");
                if (configPassword != null)
                {
                    configPassword.ParameterValue = password;
                    configPassword.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configPassword);
                }

                // عرض رسالة نجاح
                ViewBag.Message = "Configuration updated successfully!";
                return View("DatabaseConfig");
            }

            return View("DatabaseConfig");
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
