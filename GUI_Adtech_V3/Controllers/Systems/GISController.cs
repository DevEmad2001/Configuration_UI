using GUI_Adtech.Models;
using GUI_Adtech.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GUI_Adtech.Controllers.Systems
{
    public class GISController : Controller
    {

        private readonly IConfigRepository _configRepository;

        public GISController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GISUDA()
        {
            // الحصول على القيم من قاعدة البيانات بناءً على ComponentName "GISUDA"
            var serviceUrlConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", "GISUDA");
            var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", "GISUDA");
            var authenticationConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", "GISUDA");
            var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", "GISUDA");

            // تمرير القيم إلى ViewBag لعرضها في الـ View
            ViewBag.ServiceURL = serviceUrlConfig?.ParameterValue;
            ViewBag.Binding = bindingConfig?.ParameterValue;
            ViewBag.Authentication = authenticationConfig?.ParameterValue;
            ViewBag.Protocol = protocolConfig?.ParameterValue;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GISUDAConfig(
    string serviceURL, string binding, string authentication,
    string basicUsername, string basicPassword,
    string certificatePath, string certificatePassword,
    string token, string protocol)
        {
            string componentName = "GISUDA";

            if (ModelState.IsValid)
            {
                // تحديث أو إضافة ServiceURL و Binding و Authentication و Protocol
                await _configRepository.UpdateOrInsertConfigAsync("ServiceURL", serviceURL, componentName);
                await _configRepository.UpdateOrInsertConfigAsync("Binding", binding, componentName);
                await _configRepository.UpdateOrInsertConfigAsync("Authentication", authentication, componentName);
                await _configRepository.UpdateOrInsertConfigAsync("Protocol", protocol, componentName);

                // التحقق من اختيار نوع Authentication وتحديث القيم بناءً عليه
                if (authentication == "basic")
                {
                    await _configRepository.UpdateOrInsertConfigAsync("Username", basicUsername, componentName);
                    await _configRepository.UpdateOrInsertConfigAsync("Password", basicPassword, componentName);

                    // التأكد من أن القيم الأخرى تصبح NULL
                    await _configRepository.SetNullIfExistsAsync("CertificatePath", componentName);
                    await _configRepository.SetNullIfExistsAsync("CertificatePassword", componentName);
                    await _configRepository.SetNullIfExistsAsync("Token", componentName);
                }
                else if (authentication == "certificate")
                {
                    await _configRepository.UpdateOrInsertConfigAsync("CertificatePath", certificatePath, componentName);
                    await _configRepository.UpdateOrInsertConfigAsync("CertificatePassword", certificatePassword, componentName);

                    // التأكد من أن القيم الأخرى تصبح NULL
                    await _configRepository.SetNullIfExistsAsync("Username", componentName);
                    await _configRepository.SetNullIfExistsAsync("Password", componentName);
                    await _configRepository.SetNullIfExistsAsync("Token", componentName);
                }

                else if (authentication == "token")
                {
                    await _configRepository.UpdateOrInsertConfigAsync("Token", token, componentName);

                    // التأكد من أن القيم الأخرى تصبح NULL
                    await _configRepository.SetNullIfExistsAsync("Username", componentName);
                    await _configRepository.SetNullIfExistsAsync("Password", componentName);
                    await _configRepository.SetNullIfExistsAsync("CertificatePath", componentName);
                    await _configRepository.SetNullIfExistsAsync("CertificatePassword", componentName);
                }
                // عرض رسالة نجاح
                TempData["Message"] = "GISUDA Configuration updated successfully!";
                return RedirectToAction("GISUDA");
            }

            return View("GISUDA");
        }


        public IActionResult NetworkGISNode()
        {
            return View();
        }
    }
}
