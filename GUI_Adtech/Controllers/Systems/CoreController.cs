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




        [HttpGet]
        public async Task<IActionResult> FolderStructure()
        {
            // الحصول على القيم من قاعدة البيانات بناءً على ComponentName
            var serverPathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServerPath", "FolderStructure");
            var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", "FolderStructure");
            var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", "FolderStructure");

            // تمرير القيم إلى ViewBag لعرضها في الـ View
            ViewBag.ServerPath = serverPathConfig?.ParameterValue;
            ViewBag.Username = usernameConfig?.ParameterValue;
            ViewBag.Password = passwordConfig?.ParameterValue;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DatabaseConfig()
        {
            // الحصول على القيم من قاعدة البيانات بناءً على ComponentName "MeterInstallation"
            var serverPathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServerPath", "MeterInstallation");
            var portNumberConfig = await _configRepository.GetConfigByParameterAndComponentAsync("PortNumber", "MeterInstallation");
            var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", "MeterInstallation");
            var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", "MeterInstallation");

            // تمرير القيم إلى ViewBag لعرضها في الـ View
            ViewBag.ServerPath = serverPathConfig?.ParameterValue;
            ViewBag.PortNumber = portNumberConfig?.ParameterValue;
            ViewBag.Username = usernameConfig?.ParameterValue;
            ViewBag.Password = passwordConfig?.ParameterValue;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SFTPConnector()
        {
            // جلب القيم من قاعدة البيانات بناءً على ComponentName
            var serverConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Server", "SFTPConnector");
            var portNumberConfig = await _configRepository.GetConfigByParameterAndComponentAsync("PortNumber", "SFTPConnector");
            var usernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Username", "SFTPConnector");
            var passwordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Password", "SFTPConnector");
            var filePathsConfig = await _configRepository.GetConfigByParameterAndComponentAsync("FilePaths", "SFTPConnector");

            // تمرير القيم إلى ViewBag لعرضها في الـ View
            ViewBag.Server = serverConfig?.ParameterValue;
            ViewBag.PortNumber = portNumberConfig?.ParameterValue;
            ViewBag.Username = usernameConfig?.ParameterValue;
            ViewBag.Password = passwordConfig?.ParameterValue;
            ViewBag.FilePaths = filePathsConfig?.ParameterValue;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> XMLValidation()
        {
            // جلب القيم من قاعدة البيانات بناءً على ComponentName "XMLValidation"
            var readingSchemaConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ReadingSchema", "XMLValidation");
            var eventSchemaConfig = await _configRepository.GetConfigByParameterAndComponentAsync("EventSchema", "XMLValidation");
            var configSchemaConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ConfigSchema", "XMLValidation");

            // تمرير القيم إلى ViewBag لعرضها في الفورم
            ViewBag.ReadingSchema = readingSchemaConfig?.ParameterValue;
            ViewBag.EventSchema = eventSchemaConfig?.ParameterValue;
            ViewBag.ConfigSchema = configSchemaConfig?.ParameterValue;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DatabaseConfig(string serverPath, string portNumber, string username, string password)
        {
            if (ModelState.IsValid)
            {
                //تحديث أو إضافة ServerPath
                var configServerPath = await _configRepository.GetConfigByParameterNameAsync("ServerPath");
                if (configServerPath != null)
                {
                    configServerPath.ParameterValue = serverPath;
                    configServerPath.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configServerPath);
                }

                //تحديث أو إضافة PortNumber
                var configPortNumber = await _configRepository.GetConfigByParameterNameAsync("PortNumber");
                if (configPortNumber != null)
                {
                    configPortNumber.ParameterValue = portNumber;
                    configPortNumber.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configPortNumber);
                }

                //تحديث أو إضافة Username
                var configUsername = await _configRepository.GetConfigByParameterNameAsync("Username");
                if (configUsername != null)
                {
                    configUsername.ParameterValue = username;
                    configUsername.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configUsername);
                }

                //تحديث أو إضافة Password
                var configPassword = await _configRepository.GetConfigByParameterNameAsync("Password");
                if (configPassword != null)
                {
                    configPassword.ParameterValue = password;
                    configPassword.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configPassword);
                }

                //عرض رسالة نجاح
                ViewBag.Message = "Configuration updated successfully!";
                return View("DatabaseConfig");
            }

            return View("DatabaseConfig");
        }


        [HttpPost]
        public async Task<IActionResult> SaveFolderStructure(string componentName, string serverPath, string username, string password)
        {
            if (ModelState.IsValid)
            {
                // تحديث أو إضافة ServerPath بناءً على ComponentName
                var configServerPath = await _configRepository.GetConfigByParameterAndComponentAsync("ServerPath", componentName);
                if (configServerPath != null)
                {
                    configServerPath.ParameterValue = serverPath;
                    configServerPath.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configServerPath);
                }
                else
                {
                    configServerPath = new AdtechConfig
                    {
                        ParameterName = "ServerPath",
                        ParameterValue = serverPath,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(configServerPath);
                }

                // تحديث أو إضافة Username بناءً على ComponentName
                var configUsername = await _configRepository.GetConfigByParameterAndComponentAsync("Username", componentName);
                if (configUsername != null)
                {
                    configUsername.ParameterValue = username;
                    configUsername.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configUsername);
                }
                else
                {
                    configUsername = new AdtechConfig
                    {
                        ParameterName = "Username",
                        ParameterValue = username,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(configUsername);
                }

                // تحديث أو إضافة Password بناءً على ComponentName
                var configPassword = await _configRepository.GetConfigByParameterAndComponentAsync("Password", componentName);
                if (configPassword != null)
                {
                    configPassword.ParameterValue = password;
                    configPassword.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configPassword);
                }
                else
                {
                    configPassword = new AdtechConfig
                    {
                        ParameterName = "Password",
                        ParameterValue = password,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(configPassword);
                }

                // عرض رسالة نجاح
                ViewBag.Message = $"Folder Structure Configuration updated for component: {componentName}!";
                return View("FolderStructure");
            }

            return View("FolderStructure");
        }


        [HttpPost]
        public async Task<IActionResult> SFTPConnector(string server, string portNumber, string username, string password, string filePaths)
        {
            string componentName = "SFTPConnector";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة Server
                var serverConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Server", componentName);
                if (serverConfig != null)
                {
                    serverConfig.ParameterValue = server;
                    serverConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(serverConfig);
                }
                else
                {
                    serverConfig = new AdtechConfig
                    {
                        ParameterName = "Server",
                        ParameterValue = server,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(serverConfig);
                }

                // تحديث أو إضافة PortNumber
                var portNumberConfig = await _configRepository.GetConfigByParameterAndComponentAsync("PortNumber", componentName);
                if (portNumberConfig != null)
                {
                    portNumberConfig.ParameterValue = portNumber;
                    portNumberConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(portNumberConfig);
                }
                else
                {
                    portNumberConfig = new AdtechConfig
                    {
                        ParameterName = "PortNumber",
                        ParameterValue = portNumber,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(portNumberConfig);
                }

                // تحديث أو إضافة Username
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

                // تحديث أو إضافة Password
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

                // تحديث أو إضافة FilePaths
                var filePathsConfig = await _configRepository.GetConfigByParameterAndComponentAsync("FilePaths", componentName);
                if (filePathsConfig != null)
                {
                    filePathsConfig.ParameterValue = filePaths;
                    filePathsConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(filePathsConfig);
                }
                else
                {
                    filePathsConfig = new AdtechConfig
                    {
                        ParameterName = "FilePaths",
                        ParameterValue = filePaths,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(filePathsConfig);
                }

                // عرض رسالة نجاح
                ViewBag.Message = "SFTP Connector Configuration updated successfully!";
                return RedirectToAction("SFTPConnector"); // إعادة عرض الصفحة مع القيم المحدثة
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> XMLValidation(string readingSchema, string eventSchema, string configSchema)
        {
            string componentName = "XMLValidation";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة ReadingSchema
                var readingSchemaConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ReadingSchema", componentName);
                if (readingSchemaConfig != null)
                {
                    readingSchemaConfig.ParameterValue = readingSchema;
                    readingSchemaConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(readingSchemaConfig);
                }
                else
                {
                    readingSchemaConfig = new AdtechConfig
                    {
                        ParameterName = "ReadingSchema",
                        ParameterValue = readingSchema,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(readingSchemaConfig);
                }

                // تحديث أو إضافة EventSchema
                var eventSchemaConfig = await _configRepository.GetConfigByParameterAndComponentAsync("EventSchema", componentName);
                if (eventSchemaConfig != null)
                {
                    eventSchemaConfig.ParameterValue = eventSchema;
                    eventSchemaConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(eventSchemaConfig);
                }
                else
                {
                    eventSchemaConfig = new AdtechConfig
                    {
                        ParameterName = "EventSchema",
                        ParameterValue = eventSchema,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(eventSchemaConfig);
                }

                // تحديث أو إضافة ConfigSchema
                var configSchemaConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ConfigSchema", componentName);
                if (configSchemaConfig != null)
                {
                    configSchemaConfig.ParameterValue = configSchema;
                    configSchemaConfig.ModifiesDate = DateTime.Now;
                    await _configRepository.UpdateConfigAsync(configSchemaConfig);
                }
                else
                {
                    configSchemaConfig = new AdtechConfig
                    {
                        ParameterName = "ConfigSchema",
                        ParameterValue = configSchema,
                        ComponentName = componentName,
                        ModifiesDate = DateTime.Now
                    };
                    await _configRepository.AddConfigAsync(configSchemaConfig);
                }

                // عرض رسالة نجاح
                ViewBag.Message = "XML Validation Configuration updated successfully!";
                return RedirectToAction("XMLValidation");
            }

            return View();
        }



        //public IActionResult XMLValidation()
        //{
        //    return View();
        //}
    }
}
