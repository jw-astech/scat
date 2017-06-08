using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using dot_not_a_goat.Models;

namespace dot_not_a_goat.Controllers
{
    public class CommentController : DbContextController
    {
        // POST: Comment
        [HttpPost]
        public ActionResult Add(int messageId, string commentText)
        {
            string userId = User.Identity.GetUserId();
            UserCommentModel userCommentModel = new UserCommentModel();
            userCommentModel.addComment(messageId, userId, commentText);
            return RedirectToAction("Detail", "Message", new { id = messageId });
        }
    }
}