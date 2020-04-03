﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMono.Controllers
{
    public class HomeController : Controller
    {
     

        //MonoRepos db_Repos = new MonoRepos();
        public IActionResult Index()
        {
            return View();
        }



        #region ne upotrebljava se
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

   
        #endregion
    }
}