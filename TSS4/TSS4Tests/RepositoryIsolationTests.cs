﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4;
using TSS4.Repository;
using TSS4.Views;

namespace TSS4Tests.Tests
{

    [TestFixture]
    public class UserRepositoryTest
    {
        private  MockServer Mock { get; set; }
        private bool Started { get; set; } = false;

        [SetUp]
        public void SetUpWireMock()
        {
            if(!Started)
            {
                Mock = new MockServer();
                Mock.Start("5000");
                Started = true;
            }           
        }

        [Test]
        public void UserGetTest()
        {
            Mock.StubUsers("Bob", "url", 4, "users/SovaBob");
            UserRepository rep = new UserRepository();
            int result = rep.Get(Mock.BaseUrl, "SovaBob");
            Assert.AreEqual(result, 200);
            User user = new User()
            {
                Login = "Bob",
                Url = "url",
                Public_repos = 4
            };
            Assert.AreEqual(rep.User.Login, user.Login);
            Assert.AreEqual(rep.User.Url, user.Url);
            Assert.AreEqual(rep.User.Public_repos, user.Public_repos);
        }
    }
}
