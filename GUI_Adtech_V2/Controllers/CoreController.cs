﻿using Microsoft.AspNetCore.Mvc;

namespace GUI_Adtech_V2.Controllers
{
    public class CoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
