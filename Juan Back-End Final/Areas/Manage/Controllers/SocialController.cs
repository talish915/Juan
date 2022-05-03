using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Areas.Manage.Controllers
{
    public class SocialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
