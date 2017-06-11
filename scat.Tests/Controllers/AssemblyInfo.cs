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
    public class AssemblyInfo
    {
        [TestMethod()]
        public void GetTest()
        {
            UpdateUserController uuController = new UpdateUserController();
            IEnumerable<string> foo = uuController.Get();
            IEnumerable<string> bar = new string[] { "value1", "value2" };
            Assert.IsTrue(foo.ElementAt(0) == bar.ElementAt(0));
        }
    }


}