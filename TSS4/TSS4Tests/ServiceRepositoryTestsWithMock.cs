using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4;
using TSS4.Repository;
using TSS4.Views;
using TSS4.Service;

namespace TSS4Tests.Tests
{

    [TestFixture]
    public class UserServiceRepositoryTestsMock
    {
        private MockServer Mock { get; set; }
        private bool Started { get; set; } = false;

        [SetUp]
        public void SetUpWireMock()
        {
            if (!Started)
            {
                Mock = new MockServer();
                Mock.Start("5001");
                Started = true;
            }
        }

        [Test]
        public void ServiceRepositoryMock()
        {
            Mock.StubUsers("SovaBob", "https://api.github.com/users/SovaBob", 4, "users/SovaBob");      

            UserService serv = new UserService(new UserRepository(Mock.BaseUrl));


            var result = serv.CheckUserWork("SovaBob");
            var expected = "User: SovaBob has 4 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);

            Mock.Stop();
        }    
    }
}
