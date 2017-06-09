using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scat.Models
{
    public class UserCommentModel
    {

        public UserCommentModel() { }

        public UserComment addComment(int messageId, string userId, string commentText)
        {
            UserComment userComment = new UserComment();
            userComment.messageId = messageId;
            userComment.commentText = commentText;
            userComment.commeterId = userId;
            using (var entDb = new EntityDbContext())
            {
                entDb.UserComments.Add(userComment);
                entDb.SaveChanges();
            }
            return userComment;
        }
    }
}