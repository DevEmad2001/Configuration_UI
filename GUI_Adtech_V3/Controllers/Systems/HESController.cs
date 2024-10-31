using GUI_Adtech.Models;
using GUI_Adtech.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace GUI_Adtech.Controllers.Systems
{
    public class HESController : Controller
    {
        private readonly IConfigRepository _configRepository;
        private readonly IAuthConfigRepository _authConfigRepository;

        public HESController(IConfigRepository configRepository, IAuthConfigRepository authConfigRepository)
        {
            _configRepository = configRepository;
            _authConfigRepository = authConfigRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MeterInstallation()
        {
            // الحصول على القيم من قاعدة البيانات بناءً على ComponentName
            var filewatcherPathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("FilewatcherPath", "MeterInstallation");
            var dbLinkConfig = await _configRepository.GetConfigByParameterAndComponentAsync("DBLink", "MeterInstallation");
            var logfilePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("LogfilePath", "MeterInstallation");

            // تمرير القيم إلى ViewBag لعرضها في الـ View
            ViewBag.FilewatcherPath = filewatcherPathConfig?.ParameterValue;
            ViewBag.DBLink = dbLinkConfig?.ParameterValue;
            ViewBag.LogfilePath = logfilePathConfig?.ParameterValue;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MeterInstallationConfig(string filewatcherPath, string dbLink, string logfilePath)
        {
            string componentName = "MeterInstallation";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة Filewatcher Path
                var filewatcherPathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("FilewatcherPath", componentName);
                if (filewatcherPathConfig != null)
                {
                    filewatcherPathConfig.ParameterValue = filewatcherPath;
                    filewatcherPathConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(filewatcherPathConfig);
                }
                else
                {
                    filewatcherPathConfig = new AdtechConfig
                    {
                        ParameterName = "FilewatcherPath",
                        ParameterValue = filewatcherPath,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(filewatcherPathConfig);
                }

                // تحديث أو إضافة DB Link
                var dbLinkConfig = await _configRepository.GetConfigByParameterAndComponentAsync("DBLink", componentName);
                if (dbLinkConfig != null)
                {
                    dbLinkConfig.ParameterValue = dbLink;
                    dbLinkConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(dbLinkConfig);
                }
                else
                {
                    dbLinkConfig = new AdtechConfig
                    {
                        ParameterName = "DBLink",
                        ParameterValue = dbLink,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(dbLinkConfig);
                }

                // تحديث أو إضافة Log File Path
                var logfilePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("LogfilePath", componentName);
                if (logfilePathConfig != null)
                {
                    logfilePathConfig.ParameterValue = logfilePath;
                    logfilePathConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(logfilePathConfig);
                }
                else
                {
                    logfilePathConfig = new AdtechConfig
                    {
                        ParameterName = "LogfilePath",
                        ParameterValue = logfilePath,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(logfilePathConfig);
                }

                // عرض رسالة نجاح
                ViewBag.Message = "Meter Installation Configuration updated successfully!";
                return RedirectToAction("MeterInstallation");
            }

            return View("MeterInstallation");
        }


        [HttpGet]
        public async Task<IActionResult> DailyReading()
        {
            // الحصول على القيم من قاعدة البيانات بناءً على ComponentName
            var filewatcherPathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("FilewatcherPath", "DailyReading");
            var dbLinkConfig = await _configRepository.GetConfigByParameterAndComponentAsync("DBLink", "DailyReading");
            var logfilePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("LogfilePath", "DailyReading");

            // تمرير القيم إلى ViewBag لعرضها في الـ View
            ViewBag.FilewatcherPath = filewatcherPathConfig?.ParameterValue;
            ViewBag.DBLink = dbLinkConfig?.ParameterValue;
            ViewBag.LogfilePath = logfilePathConfig?.ParameterValue;

            return View();
        }




        [HttpPost]
        public async Task<IActionResult> DailyReadingConfig(string filewatcherPath, string dbLink, string logfilePath)
        {
            string componentName = "DailyReading";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة Filewatcher Path
                var filewatcherPathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("FilewatcherPath", componentName);
                if (filewatcherPathConfig != null)
                {
                    filewatcherPathConfig.ParameterValue = filewatcherPath;
                    filewatcherPathConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(filewatcherPathConfig);
                }
                else
                {
                    filewatcherPathConfig = new AdtechConfig
                    {
                        ParameterName = "FilewatcherPath",
                        ParameterValue = filewatcherPath,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(filewatcherPathConfig);
                }

                // تحديث أو إضافة DB Link
                var dbLinkConfig = await _configRepository.GetConfigByParameterAndComponentAsync("DBLink", componentName);
                if (dbLinkConfig != null)
                {
                    dbLinkConfig.ParameterValue = dbLink;
                    dbLinkConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(dbLinkConfig);
                }
                else
                {
                    dbLinkConfig = new AdtechConfig
                    {
                        ParameterName = "DBLink",
                        ParameterValue = dbLink,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(dbLinkConfig);
                }

                // تحديث أو إضافة Log File Path
                var logfilePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("LogfilePath", componentName);
                if (logfilePathConfig != null)
                {
                    logfilePathConfig.ParameterValue = logfilePath;
                    logfilePathConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(logfilePathConfig);
                }
                else
                {
                    logfilePathConfig = new AdtechConfig
                    {
                        ParameterName = "LogfilePath",
                        ParameterValue = logfilePath,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(logfilePathConfig);
                }

                // عرض رسالة نجاح
                ViewBag.Message = "Daily Reading Configuration updated successfully!";
                return RedirectToAction("DailyReading");
            }

            return View("DailyReading");
        }



        [HttpGet]
        public async Task<IActionResult> ControlService()
        {
            // استرجاع الإعدادات من قاعدة البيانات لكل إعداد مطلوب
            var serviceURLConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", "ControlService");
            var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", "ControlService");
            var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", "ControlService");
            var authenticationConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", "ControlService");
            var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", "ControlService");
            var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", "ControlService");
            var tokenConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Token", "ControlService");
            var certificatePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("CertificatePath", "ControlService");

            // تمرير القيم إلى ViewBag لعرضها في الواجهة
            ViewBag.ServiceURL = serviceURLConfig?.ParameterValue;
            ViewBag.Binding = bindingConfig?.ParameterValue;
            ViewBag.Protocol = protocolConfig?.ParameterValue;
            ViewBag.Authentication = authenticationConfig?.ParameterValue;
            ViewBag.Username = usernameConfig?.ParameterValue;
            ViewBag.Password = passwordConfig?.ParameterValue;
            ViewBag.Token = tokenConfig?.ParameterValue;
            ViewBag.CertificatePath = certificatePathConfig?.ParameterValue;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ControlService(
            string serviceURL,
            string binding,
            string protocol,
            string authentication,
            string username,
            string password,
            string token,
            string certificatePath)
        {
            string componentName = "ControlService";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة الحقول مباشرة كما في MeterInstallation
                await UpdateOrInsertConfigAsync("ServiceURL", serviceURL, componentName);
                await UpdateOrInsertConfigAsync("Binding", binding, componentName);
                await UpdateOrInsertConfigAsync("Protocol", protocol, componentName);
                await UpdateOrInsertConfigAsync("Authentication", authentication, componentName);
                await UpdateOrInsertConfigAsync("Username", username, componentName);
                await UpdateOrInsertConfigAsync("Password", password, componentName);
                await UpdateOrInsertConfigAsync("Token", token, componentName);
                await UpdateOrInsertConfigAsync("CertificatePath", certificatePath, componentName);

                // إعداد رسالة النجاح
                TempData["Message"] = "Control Service Configuration updated successfully!";
                return RedirectToAction("ControlService");
            }

            return View();
        }

        private async Task UpdateOrInsertConfigAsync(string parameterName, string parameterValue, string componentName)
        {
            var config = await _configRepository.GetConfigByParameterAndComponentAsync(parameterName, componentName);
            if (config != null)
            {
                config.ParameterValue = parameterValue;
                config.ModifiesDate = DateTime.Now;
                await _configRepository.UpdateConfigAsync(config);
            }
            else
            {
                config = new AdtechConfig
                {
                    ParameterName = parameterName,
                    ParameterValue = parameterValue,
                    ComponentName = componentName,
                    ModifiesDate = DateTime.Now
                };
                await _configRepository.AddConfigAsync(config);
            }
        }








        [HttpGet]
        public async Task<IActionResult> DataService()
        {
            var serviceURLConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", "DataService");
            var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", "DataService");
            var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", "DataService");
            var authenticationConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", "DataService");
            var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", "DataService");
            var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", "DataService");
            var tokenConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Token", "DataService");
            var certificateNameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("CertificateName", "DataService");
            var certificatePasswordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("CertificatePassword", "DataService");

            ViewBag.ServiceURL = serviceURLConfig?.ParameterValue;
            ViewBag.Binding = bindingConfig?.ParameterValue;
            ViewBag.Protocol = protocolConfig?.ParameterValue;
            ViewBag.Authentication = authenticationConfig?.ParameterValue;
            ViewBag.Username = usernameConfig?.ParameterValue;
            ViewBag.Password = passwordConfig?.ParameterValue;
            ViewBag.Token = tokenConfig?.ParameterValue;
            ViewBag.CertificateName = certificateNameConfig?.ParameterValue;
            ViewBag.CertificatePassword = certificatePasswordConfig?.ParameterValue;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DataService(
            string serviceURL,
            string binding,
            string protocol,
            string authentication,
            string username,
            string password,
            string token,
            string certificateName,
            string certificatePassword)
        {
            if (ModelState.IsValid)
            {
                await UpdateOrInsertConfigForDataService("ServiceURL", serviceURL);
                await UpdateOrInsertConfigForDataService("Binding", binding);
                await UpdateOrInsertConfigForDataService("Protocol", protocol);
                await UpdateOrInsertConfigForDataService("Authentication", authentication);
                await UpdateOrInsertConfigForDataService("Username", username);
                await UpdateOrInsertConfigForDataService("Password", password);
                await UpdateOrInsertConfigForDataService("Token", token);
                await UpdateOrInsertConfigForDataService("CertificateName", certificateName);
                await UpdateOrInsertConfigForDataService("CertificatePassword", certificatePassword);

                TempData["Message"] = "Data Service Configuration updated successfully!";
                return RedirectToAction("DataService");
            }

            return View();
        }

        private async Task UpdateOrInsertConfigForDataService(string parameterName, string parameterValue)
        {
            var config = await _configRepository.GetConfigByParameterAndComponentAsync(parameterName, "DataService");
            if (config != null)
            {
                config.ParameterValue = parameterValue;
                config.ModifiesDate = DateTime.Now;
                await _configRepository.UpdateConfigAsync(config);
            }
            else
            {
                config = new AdtechConfig
                {
                    ParameterName = parameterName,
                    ParameterValue = parameterValue,
                    ComponentName = "DataService",
                    ModifiesDate = DateTime.Now
                };
                await _configRepository.AddConfigAsync(config);
            }
        }




    }
}


























