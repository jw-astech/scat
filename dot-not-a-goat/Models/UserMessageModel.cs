using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dot_not_a_goat.Models
{
    public class UserMessageModel
    {
        public UserMessageModel() { }

        public UserMessage addMessage(string userId, string messageText)
        {
            
            UserMessage newMessage = new UserMessage();
            newMessage.messageText = messageText;
            newMessage.posterId = userId;
            newMessage.postedDate = DateTime.Now;
           

            using (var entDB = new EntityDbContext())
            {
                entDB.UserMessages.Add(newMessage);
                entDB.SaveChanges();
            }

            return newMessage;
        }

    }
}