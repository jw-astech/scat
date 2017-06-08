using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dot_not_a_goat.Models;
using Microsoft.AspNet.Identity;

namespace dot_not_a_goat.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [ValidateInput(false)]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            // show messages of those I follow
            UserIndexViewModel userIndexModel = new UserIndexViewModel(userId);
            return View(userIndexModel);
        }

        [ValidateInput(false)]
        public ActionResult Detail(string id)
        {
            UserDetailViewModel userDetailModel = new UserDetailViewModel(id);
            return View(userDetailModel);
        }
    }
}