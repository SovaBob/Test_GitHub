using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4.Service;
using TSS4.Repository;
using TSS4.Views;

namespace TSS4Tests.Tests
{
    [TestFixture]
    public class ServiceTests
    {
       
        [Test]
        public void CreateServiceTest()
        {
            UserService serv = new UserService(new UserRepository(""));
            Assert.IsNotNull(serv.rep);
        }

        [Test]
        public void ProcessServiceTest()
        {
            UserService serv = new UserService(new UserRepository(""));

            serv.rep.User = new User()
            {
                Login = "Bob",
                Url = "url",
                Public_repos = 4
            };

            string result = serv.Process();
            string expected = "User: Bob has 4 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void CheckUserWorkTestIsolation()
        {
            UserService serv = new UserService(new MockUserRepository(""));
            
            string result = serv.CheckUserWork("SovaBob");
            string expected = "User: SovaBob has 4 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);
        }
    }
}
