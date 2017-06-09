using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scat.Models
{
    public class MessageDetailViewModel
    {
        public UserMessage message;
        public List<UserComment> comments;

        public MessageDetailViewModel(string id) {
            int intId = Int32.Parse(id);
            using (var entDB = new EntityDbContext())
            {
                message = entDB.UserMessages.Find(intId);

                var messageComments = from uc in entDB.UserComments
                               where uc.messageId == intId
                               select uc;
                comments = messageComments.ToList();
            }
        }
    }
}