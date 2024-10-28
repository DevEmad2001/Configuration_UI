using GUI_Adtech.Models;
using GUI_Adtech.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace GUI_Adtech.Controllers.Systems
{
    public class HESController : Controller
    {
        private readonly IConfigRepository _configRepository;

        public HESController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
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


        public IActionResult DailyReading()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DataService()
        {
            string componentName = "DataService";

            // جلب البيانات المخزنة من قاعدة البيانات
            var serviceURLConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", componentName);
            var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", componentName);
            var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", componentName);
            var authenticationConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", componentName);
            var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", componentName);
            var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", componentName);
            var tokenConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Token", componentName);
            var certificatePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("CertificatePath", componentName);

            // تمرير القيم إلى ViewBag لعرضها في الـ View
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
        public async Task<IActionResult> SaveDataServiceConfig(string serviceURL, string binding, string protocol, string authentication, string username, string password, string token, IFormFile certificate)
        {
            string componentName = "DataService";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة ServiceURL
                var serviceURLConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", componentName);
                if (serviceURLConfig != null)
                {
                    serviceURLConfig.ParameterValue = serviceURL;
                    serviceURLConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(serviceURLConfig);
                }
                else
                {
                    serviceURLConfig = new AdtechConfig
                    {
                        ParameterName = "ServiceURL",
                        ParameterValue = serviceURL,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(serviceURLConfig);
                }

                // تحديث أو إضافة Binding
                var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", componentName);
                if (bindingConfig != null)
                {
                    bindingConfig.ParameterValue = binding;
                    bindingConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(bindingConfig);
                }
                else
                {
                    bindingConfig = new AdtechConfig
                    {
                        ParameterName = "Binding",
                        ParameterValue = binding,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(bindingConfig);
                }

                // تحديث أو إضافة Protocol
                var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", componentName);
                if (protocolConfig != null)
                {
                    protocolConfig.ParameterValue = protocol;
                    protocolConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(protocolConfig);
                }
                else
                {
                    protocolConfig = new AdtechConfig
                    {
                        ParameterName = "Protocol",
                        ParameterValue = protocol,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(protocolConfig);
                }

                // حفظ أو تحديث بيانات Authentication بناءً على الاختيار
                if (authentication == "basic")
                {
                    var authConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", componentName);
                    if (authConfig == null)
                    {
                        authConfig = new AdtechConfig
                        {
                            ParameterName = "Authentication",
                            ParameterValue = "basic",
                            ComponentName = componentName,
                            ModifiesDate = DateTime.Now
                        };
                        await _configRepository.AddConfigAsync(authConfig);
                    }

                    var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", componentName);
                    if (usernameConfig != null)
                    {
                        usernameConfig.ParameterValue = username;
                        usernameConfig.ModifiesDate = DateTime.Now;
                        await _configRepository.UpdateConfigAsync(usernameConfig);
                    }
                    else
                    {
                        usernameConfig = new AdtechConfig
                        {
                            ParameterName = "Username",
                            ParameterValue = username,
                            ComponentName = componentName,
                            ModifiesDate = DateTime.Now
                        };
                        await _configRepository.AddConfigAsync(usernameConfig);
                    }

                    var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", componentName);
                    if (passwordConfig != null)
                    {
                        passwordConfig.ParameterValue = password;
                        passwordConfig.ModifiesDate = DateTime.Now;
                        await _configRepository.UpdateConfigAsync(passwordConfig);
                    }
                    else
                    {
                        passwordConfig = new AdtechConfig
                        {
                            ParameterName = "Password",
                            ParameterValue = password,
                            ComponentName = componentName,
                            ModifiesDate = DateTime.Now
                        };
                        await _configRepository.AddConfigAsync(passwordConfig);
                    }
                }
                else if (authentication == "certificate")
                {
                    // حفظ بيانات الشهادة
                    if (certificate != null && certificate.Length > 0)
                    {
                        var certificatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates", certificate.FileName);
                        using (var stream = new FileStream(certificatePath, FileMode.Create))
                        {
                            await certificate.CopyToAsync(stream);
                        }

                        var certificateConfig = new AdtechConfig
                        {
                            ParameterName = "CertificatePath",
                            ParameterValue = certificatePath,
                            ComponentName = componentName,
                            ModifiesDate = DateTime.Now
                        };
                        await _configRepository.AddConfigAsync(certificateConfig);
                    }
                }
                else if (authentication == "token")
                {
                    var authConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", componentName);
                    if (authConfig == null)
                    {
                        authConfig = new AdtechConfig
                        {
                            ParameterName = "Authentication",
                            ParameterValue = "token",
                            ComponentName = componentName,
                            ModifiesDate = DateTime.Now
                        };
                        await _configRepository.AddConfigAsync(authConfig);
                    }

                    var tokenConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Token", componentName);
                    if (tokenConfig != null)
                    {
                        tokenConfig.ParameterValue = token;
                        tokenConfig.ModifiesDate = DateTime.Now;
                        await _configRepository.UpdateConfigAsync(tokenConfig);
                    }
                    else
                    {
                        tokenConfig = new AdtechConfig
                        {
                            ParameterName = "Token",
                            ParameterValue = token,
                            ComponentName = componentName,
                            ModifiesDate = DateTime.Now
                        };
                        await _configRepository.AddConfigAsync(tokenConfig);
                    }
                }

                // عرض رسالة نجاح
                ViewBag.Message = "Data Service Configuration updated successfully!";
                return RedirectToAction("DataService");
            }

            return View("DataService");
        }





        [HttpGet]
        public async Task<IActionResult> ControlService()
        {
            // جلب القيم من قاعدة البيانات بناءً على ComponentName
            var serviceURLConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", "ControlService");
            var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", "ControlService");
            var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", "ControlService");
            var authenticationConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", "ControlService");

            ViewBag.ServiceURL = serviceURLConfig?.ParameterValue;
            ViewBag.Binding = bindingConfig?.ParameterValue;
            ViewBag.Protocol = protocolConfig?.ParameterValue;
            ViewBag.Authentication = authenticationConfig?.ParameterValue;

            if (authenticationConfig?.ParameterValue == "basic")
            {
                var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", "ControlService");
                var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", "ControlService");
                ViewBag.Username = usernameConfig?.ParameterValue;
                ViewBag.Password = passwordConfig?.ParameterValue;
            }
            else if (authenticationConfig?.ParameterValue == "token")
            {
                var tokenConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Token", "ControlService");
                ViewBag.Token = tokenConfig?.ParameterValue;
            }

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
            IFormFile certificate)
        {
            string componentName = "ControlService";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة ServiceURL
                await UpdateOrInsertConfig("ServiceURL", serviceURL, componentName);

                // تحديث أو إضافة Binding
                await UpdateOrInsertConfig("Binding", binding, componentName);

                // تحديث أو إضافة Protocol
                await UpdateOrInsertConfig("Protocol", protocol, componentName);

                // تحديث أو إضافة Authentication
                await UpdateOrInsertConfig("Authentication", authentication, componentName);

                // تحديث الحقول الخاصة بنوع المصادقة
                if (authentication == "basic")
                {
                    await UpdateOrInsertConfig("Username", username, componentName);
                    await UpdateOrInsertConfig("Password", password, componentName);
                }
                else if (authentication == "token")
                {
                    await UpdateOrInsertConfig("Token", token, componentName);
                }
                else if (authentication == "certificate" && certificate != null)
                {
                    // حفظ الشهادة (كمثال، حفظ مسار الشهادة)
                    var certificatePath = Path.Combine("wwwroot/uploads", certificate.FileName);
                    using (var stream = new FileStream(certificatePath, FileMode.Create))
                    {
                        await certificate.CopyToAsync(stream);
                    }
                    await UpdateOrInsertConfig("CertificatePath", certificatePath, componentName);
                }

                // عرض رسالة نجاح
                TempData["Message"] = "Control Service Configuration updated successfully!";
                return RedirectToAction("ControlService");
            }

            return View();
        }

        // دالة مساعدة للتحديث أو الإضافة
        private async Task UpdateOrInsertConfig(string parameterName, string parameterValue, string componentName)
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
                await _configRepository.AddConfigAsync(new AdtechConfig
                {
                    ParameterName = parameterName,
                    ParameterValue = parameterValue,
                    ComponentName = componentName,
                    ModifiesDate = DateTime.Now
                });
            }
        }



    }
}
