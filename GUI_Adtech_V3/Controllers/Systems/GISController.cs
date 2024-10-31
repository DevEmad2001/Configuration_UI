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

        public IActionResult NetworkGISNode()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GISUDAConfig()
        {
            var serviceURLConfig = await _configRepository.GetConfigByParameterAndComponentAsync("ServiceURL", "GISUDA");
            var bindingConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Binding", "GISUDA");
            var protocolConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Protocol", "GISUDA");
            var authenticationConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Authentication", "GISUDA");
            var basicUsernameConfig = await _configRepository.GetConfigByParameterAndComponentAsync("BasicUsername", "GISUDA");
            var basicPasswordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("BasicPassword", "GISUDA");
            var certificatePathConfig = await _configRepository.GetConfigByParameterAndComponentAsync("CertificatePath", "GISUDA");
            var certificatePasswordConfig = await _configRepository.GetConfigByParameterAndComponentAsync("CertificatePassword", "GISUDA");
            var tokenConfig = await _configRepository.GetConfigByParameterAndComponentAsync("Token", "GISUDA");

            ViewBag.ServiceURL = serviceURLConfig?.ParameterValue;
            ViewBag.Binding = bindingConfig?.ParameterValue;
            ViewBag.Protocol = protocolConfig?.ParameterValue;
            ViewBag.Authentication = authenticationConfig?.ParameterValue;
            ViewBag.BasicUsername = basicUsernameConfig?.ParameterValue;
            ViewBag.BasicPassword = basicPasswordConfig?.ParameterValue;
            ViewBag.CertificatePath = certificatePathConfig?.ParameterValue;
            ViewBag.CertificatePassword = certificatePasswordConfig?.ParameterValue;
            ViewBag.Token = tokenConfig?.ParameterValue;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GISUDAConfig(
            string serviceURL,
            string binding,
            string protocol,
            string authentication,
            string basicUsername,
            string basicPassword,
            string certificatePath,
            string certificatePassword,
            string token)
        {
            string componentName = "GISUDA";

            if (ModelState.IsValid)
            {
                await _configRepository.UpdateOrInsertConfigAsync("ServiceURL", serviceURL, componentName);
                await _configRepository.UpdateOrInsertConfigAsync("Binding", binding, componentName);
                await _configRepository.UpdateOrInsertConfigAsync("Protocol", protocol, componentName);
                await _configRepository.UpdateOrInsertConfigAsync("Authentication", authentication, componentName);

                if (authentication == "basic")
                {
                    await _configRepository.UpdateOrInsertConfigAsync("BasicUsername", basicUsername, componentName);
                    await _configRepository.UpdateOrInsertConfigAsync("BasicPassword", basicPassword, componentName);
                    await ClearUnusedFieldsAsync(componentName, new[] { "BasicUsername", "BasicPassword" });
                }
                else if (authentication == "certificate")
                {
                    await _configRepository.UpdateOrInsertConfigAsync("CertificatePath", certificatePath, componentName);
                    await _configRepository.UpdateOrInsertConfigAsync("CertificatePassword", certificatePassword, componentName);
                    await ClearUnusedFieldsAsync(componentName, new[] { "CertificatePath", "CertificatePassword" });
                }
                else if (authentication == "token")
                {
                    await _configRepository.UpdateOrInsertConfigAsync("Token", token, componentName);
                    await ClearUnusedFieldsAsync(componentName, new[] { "Token" });
                }

                TempData["Message"] = "GISUDA Configuration updated successfully!";
                return RedirectToAction("GISUDAConfig");
            }

            return View();
        }

        private async Task ClearUnusedFieldsAsync(string componentName, string[] exclude)
        {
            var unusedFields = new[] { "BasicUsername", "BasicPassword", "Token", "CertificatePath", "CertificatePassword" };
            foreach (var field in unusedFields)
            {
                if (Array.IndexOf(exclude, field) < 0)
                {
                    await _configRepository.SetNullIfExistsAsync(field, componentName);
                }
            }
        }
    }
}
