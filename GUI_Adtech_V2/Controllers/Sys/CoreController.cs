using GUI_Adtech_V2.Repos.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech_V2.Controllers.Sys
{
    public class CoreController : Controller
    {
        private readonly IConfigRepository _configRepository;

        public CoreController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }







        // عرض صفحة إعدادات قاعدة البيانات وجلب القيم المخزنة في قاعدة البيانات.




        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult DatabaseConfig()
        //{
        //    return View();
        //}

        public IActionResult DatabaseConfig()
        {
            return View();
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
