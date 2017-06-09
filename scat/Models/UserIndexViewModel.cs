using System;
using System.Collections.Generic;
using System.Linq;

namespace scat.Models

{ 
    public class UserIndexViewModel
    {
        public List<UserMessage> userMessages { get; }
        public List<AspNetUser> usersFollowed { get; }

        public UserIndexViewModel(string id)
        {
            usersFollowed = new List<AspNetUser>();
            userMessages = new List<UserMessage>();

            List<string> followingIds  = new List<string>();
            //user messages from those  I'm following
            using (var entDb = new EntityDbContext())
            {
                // get collection of users, the {id} user is following
                var following = from u in entDb.AspNetUsers
                                join ur in entDb.UserRelationShips on u.Id equals ur.followingId
                                where ur.followerId == id
                                select u;

                usersFollowed = following.ToList();

                //get messages posted by those user {id} is following
                foreach(AspNetUser followee in usersFollowed) {
                    List<UserMessage> tempMessages = (from um in entDb.UserMessages
                                                      where (um.posterId == followee.Id)
                                                      select um).Distinct().ToList();
                    userMessages.AddRange(tempMessages);
                }

                List<UserMessage> myMessages = (from um in entDb.UserMessages
                                                where um.posterId == id
                                                select um).ToList();

                //List <UserMessage> testList = (entDb.Database.SqlQuery<UserMessage>("select * from UserMessages where posterId =" + id)).ToList();

                userMessages.AddRange(myMessages);
                
            }
            //TODO: add some sane sort to messages in list
        }
    
    }
    
}