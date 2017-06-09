using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scat.Models;

namespace scat.Controllers
{
    public class DbContextController : Controller
    {
        public EntityDbContext EntDB { get; private set; }
        // GET: DbContext

        /*
        protected override void OnDisposing(bool disposing)
        {
            EntDB.Dispose();
        }
        */
        /*
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        */
    }
}