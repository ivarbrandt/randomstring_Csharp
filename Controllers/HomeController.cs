using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using randomstring.Models;

namespace randomstring.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[15];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            String finalString = new String(stringChars);

            Console.WriteLine($"******************{finalString}******************");

            ViewBag.Random = finalString;

            if (HttpContext.Session.GetInt32("count") != null)
            {
                int count = (int) HttpContext.Session.GetInt32("count") + 1;
                HttpContext.Session.SetInt32("count", count);
                ViewBag.Count = count;
            }
            else
            {
                HttpContext.Session.SetInt32("count", 1);
                ViewBag.Count = HttpContext.Session.GetInt32("count");
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}