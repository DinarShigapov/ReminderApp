using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReminderApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReminderAppTests.Model;
using ReminderApp.Model;

namespace ReminderApp.Pages.Tests
{


    [TestClass()]
    public class RegPageTests
    {
        [TestMethod()]
        public void RegPageTest()
        {
            //ReminderApp.Model.User user = new ReminderApp.Model.User();
            //user = UserInfo.userInfo;

            string login = "432";
            ReminderDBREntities DB = new ReminderDBREntities();
            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();
            Assert.IsTrue(loginCheck != null);
        }
    }
}