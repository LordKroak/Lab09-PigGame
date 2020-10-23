﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PigGame.Models;

namespace PigGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Roll()
        {

        }
        public IActionResult Hold()
        {

        }
        public IActionResult NewGame()
        {

        }
        
        public IActionResult Index()
        {
            var session = new PigSession(HttpContext.Session);
            return View();
        }
    }
}