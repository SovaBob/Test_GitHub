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
using TSS4.Service;

namespace TSS4Tests.Tests
{

    [TestFixture]
    public class UserServiceRepositoryTests
    {
       
        [Test]
        public void ServiceRepositoryMock()
        {
            UserService serv = new UserService(new UserRepository("https://api.github.com/"));


            var result = serv.CheckUserWork("SovaBob");
            var expected = "User: SovaBob has 4 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);

        }
    }
}
