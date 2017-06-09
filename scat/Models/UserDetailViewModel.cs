using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scat.Models
{
    public class UserDetailViewModel
    {
        public AspNetUser user { get;}
        [System.Web.Mvc.AllowHtml]
        public List<UserMessage> userMessages { get; }

        public UserDetailViewModel(string id) {
            using (var entDB = new EntityDbContext())
            {
                user = entDB.AspNetUsers.Find(id);

                var selectedMessages = from m in entDB.UserMessages
                                       where m.posterId == id
                                       select m;
                userMessages = selectedMessages.ToList();

            }
        }
    }
}