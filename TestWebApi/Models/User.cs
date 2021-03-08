using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  UserName { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool Status { get; set; }

    }
}
