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
            //ReminderApp.Model.User user = new ReminderApp.Model.User();
            //user = UserInfo.userInfo;

            string login = "765";
            string password = "345";
            string name = "dasd";

            ReminderDBREntities DB = new ReminderDBREntities();

            User testuser = new User() 
            {Name = name, Login = login, Password = password };

            DB.User.Add(testuser);
            DB.SaveChanges();

            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();
            Assert.IsTrue(loginCheck != null);
        }

        [TestMethod()]
        public void EditTest()
        {
            ReminderDBREntities DB = new ReminderDBREntities();
            string login = "765";
            string buffer = "asdad";

            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();

            loginCheck.Name = buffer;

            DB.SaveChanges();

            var loginCheck2 = DB.User.Where(x => x.Login == login).FirstOrDefault();


            Assert.IsTrue(loginCheck2.Name == buffer);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            ReminderDBREntities DB = new ReminderDBREntities();
            string login = "765";

            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();

            DB.User.Remove(loginCheck);

            DB.SaveChanges();

            var loginCheck2 = DB.User.Where(x => x.Login == login).FirstOrDefault();


            Assert.IsTrue(loginCheck2 == null);
        }


        [TestMethod()]
        public void Start()
        {
            RegPageTest();
            EditTest();
            DeleteTest();
        }
    }
}