using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Model
{
    public class Users
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Users(int iD, string name, string email, string password)
        {
            ID = iD;
            Name = name;
            Email = email;
            Password = password;
        }

        public Users()
        {

        }
    }
}
