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
        public async Task<IActionResult> GISUDA()
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
        public async Task<IActionResult> GISUDA(
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
            if (ModelState.IsValid)
            {
                await UpdateOrInsertConfigAsync("ServiceURL", serviceURL, "GISUDA");
                await UpdateOrInsertConfigAsync("Binding", binding, "GISUDA");
                await UpdateOrInsertConfigAsync("Protocol", protocol, "GISUDA");
                await UpdateOrInsertConfigAsync("Authentication", authentication, "GISUDA");
                await UpdateOrInsertConfigAsync("BasicUsername", basicUsername, "GISUDA");
                await UpdateOrInsertConfigAsync("BasicPassword", basicPassword, "GISUDA");
                await UpdateOrInsertConfigAsync("CertificatePath", certificatePath, "GISUDA");
                await UpdateOrInsertConfigAsync("CertificatePassword", certificatePassword, "GISUDA");
                await UpdateOrInsertConfigAsync("Token", token, "GISUDA");

                TempData["Message"] = "GIS UDA Configuration updated successfully!";
                return RedirectToAction("GISUDA");
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
    }
}












