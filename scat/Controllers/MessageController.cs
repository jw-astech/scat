using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using scat.Models;

namespace scat.Controllers
{
    public class MessageController : Controller
    {
        // POST: Add Message
        [HttpPost]
        [Authorize]
        public ActionResult Add(string messageText)
        {
            string userId = User.Identity.GetUserId();
            UserMessageModel userMessageModel = new UserMessageModel();
            userMessageModel.addMessage(userId, messageText);
            return RedirectToAction("Index","User");
        }


        [Authorize]
        public ActionResult Detail(string id)
        {
            string userId = User.Identity.GetUserId();
            MessageDetailViewModel messageDetailViewModel = new MessageDetailViewModel(id);
            return View(messageDetailViewModel);
        }
    }
}