using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dot_not_a_goat.Models;
using Microsoft.AspNet.Identity;

namespace dot_not_a_goat.Controllers
{
    [Authorize]
    public class RelationshipController : DbContextController
    {

        // GET: Relationship
        [ValidateInput(false)]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<UserRelationShip> userRels = new List<UserRelationShip>();
            using (var entDb = new EntityDbContext())
            {
               
                var relationships = from ur in entDb.UserRelationShips
                                    where ur.followerId == userId
                                    select ur;
                int rels = relationships.Count();
                userRels = relationships.ToList();
                
            }

            //not efficient, but here we go ...
            List<AspNetUser> usersFollowing = new List<AspNetUser>();
            using (var entDb = new EntityDbContext())
            {
                foreach (UserRelationShip rel in userRels) {
                    usersFollowing.Add(entDb.AspNetUsers.Find(rel.followingId));
                }
            }

            return View(usersFollowing);
        }

        // GET: Relationship/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Relationship/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relationship/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Relationship/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
