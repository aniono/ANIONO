using Microsoft.AspNetCore.Mvc;
using System;

namespace Aniono.Contacts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
