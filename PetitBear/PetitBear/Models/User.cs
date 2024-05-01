using System;
using System.Collections.Generic;
using System.Text;

namespace PetitBear.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public bool CheckInformation()
        {
            if (!this.UserName.Equals(null) && !this.Password.Equals(null))
                return true;
            else
                return false;
        }
    }
}
