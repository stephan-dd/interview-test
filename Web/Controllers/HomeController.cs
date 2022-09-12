using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApi _api;
        public string[] colors = { "aqua", "cadetblue", "burlywood", "darkgoldenrod", "lightslategray" };
        public HomeController(IApi api)
        {
            _api = api;
        }
        public IActionResult Index()
        {
            var contacts = _api.GetContacts();
            Random rd = new Random();
            ViewData["Random"] = colors[rd.Next(0,4)];
            ViewData["Message"] = null;
            ViewData["ErrorMessage"] = null;
            return View(contacts);
        }
        public IActionResult Evolve(string value, string actionVal)
        {
            var contacts = _api.GetContacts();
            var data = _api.EvolveContact(value, actionVal);
            Random rd = new Random();
            ViewData["Random"] = colors[rd.Next(0, 4)];
            if (data != null)
            {
                string statsMsg = "";
                foreach (var i in data.stats)
                {
                    statsMsg = statsMsg + "" + i.key + " : " + i.value + ", ";
                }
                ViewData["Message"] = $"`{value}` updated with `{statsMsg}`";
                return View(nameof(Index), contacts);
            }
            ViewData["ErrorMessage"] = $"Error occured evolving hero {value}.";
            return View(nameof(Index), contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
