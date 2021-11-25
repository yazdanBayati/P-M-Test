using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.User
{
    public abstract class User
    {
        public User(string userName, string emailAddress)
        {
            this.UserName = userName;
            this.EmailAddress = emailAddress;
        }
        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
