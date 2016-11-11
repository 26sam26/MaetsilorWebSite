using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace Maetsilor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            string[] programmers = new string[] {
                "David Bisaillon",
                "Alexandre Bricault-Leduc",
                "Francis Henry",
                "Nicolas Lapointe",
                "William Lapointe",
                "Justin Leblanc",
                "Samuel Savoie-Lapierre"};

            string[] webmasters = new string[]{
                "Samuel Savoie-Lapierre",
                "Xavier Laporte"
            };

            ViewData["programmers"] = programmers;
            ViewData["webmasters"] = webmasters;
            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }


        public IActionResult MatchMaking()
        {
            ViewData["Message"] = "MatchMaking section";

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            if(returnUrl !=null)
                return LocalRedirect(returnUrl);

            return LocalRedirect("~/Home/Index"); 
        }
    }

}


