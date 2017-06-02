using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace dot_not_a_goat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
