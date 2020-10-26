using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PigGame.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace PigGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Roll()
        {
            var session = new PigSession(HttpContext.Session);
            var game = session.GetGame();
            game.Roll();
            session.SetGame(game);
            return RedirectToAction("Index");
        }
        public IActionResult Hold()
        {
            var session = new PigSession(HttpContext.Session);
            var game = session.GetGame();
            game.Hold();
            session.SetGame(game);
            return RedirectToAction("Index");
        }
        public IActionResult NewGame()
        {
            //call newgame class and store that game in the session.
            var session = new PigSession(HttpContext.Session);
            var game = session.GetGame();
            //call new game
            game.NewGame();
            //put game back into our session
            session.SetGame(game);
            //redirect to Indexs action
            return RedirectToAction("Index");
        }
        
        public IActionResult Index()
        {
            //create session
            var session = new PigSession(HttpContext.Session);
            //see if game is over
            var game = session.GetGame();
            if (game.IsOver)
            {
                TempData["Message"] = game.CurrentPlayerName + " wins!";
            }
            //pass game to index
            return View(game);
        }
    }
}
