using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSigncryptionImplementation.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string SessionKey { get; set; }
        public bool isSignedIn { get; set; }
        public void GenerateAndSetIdNumber(int IdGiven)
        {
            Id = IdGiven.ToString();
        }

    }
}
