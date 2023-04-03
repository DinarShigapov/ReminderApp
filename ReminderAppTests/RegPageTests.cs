using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReminderApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReminderAppTests.Model;

namespace ReminderApp.Pages.Tests
{


    [TestClass()]

    public class RegPageTests
    {
        [TestMethod()]
        public void RegPageTest()
        {
            //User user = new User();
            //user = UserInfo.user;

            string login = "123";
            DBReminderEntities DB = new DBReminderEntities();
            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();
            Assert.IsTrue(loginCheck != null);
        }
    }
}