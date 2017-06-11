using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scat.Models;
using Microsoft.AspNet.Identity;
using System.Web.Util;

namespace scat.Controllers
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
            //TODO handle empty or not found string
            UserDetailViewModel userDetailModel = new UserDetailViewModel(id);
            return View(userDetailModel);
        }
    }
}