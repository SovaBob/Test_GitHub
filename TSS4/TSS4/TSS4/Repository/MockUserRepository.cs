using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS4.Views;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TSS4.Repository
{
    class MockUserRepository
    {
        public User User { get; set; }
        public string BaseUrl { get; set; }

        public MockUserRepository(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public int Get(string param)
        {
            switch (param)
            {
                case "SovaBob":
                    User = new User()
                    {
                        Login = "SovaBob",
                        Url = "https://api.github.com/users/SovaBob",
                        Public_repos = 4
                    };
                    return 200;
                default:
                    return 404;
            }
        }
    }
}
