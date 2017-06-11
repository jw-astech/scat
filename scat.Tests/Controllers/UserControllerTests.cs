using Microsoft.VisualStudio.TestTools.UnitTesting;
using scat.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scat.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void DetailTest()
        {
            UserController userController = new UserController();
            var result = userController.Detail("4d72163d-acc2-41da-9dd5-3898030f95b9");
            Assert.IsTrue(true);
        }
    }
}