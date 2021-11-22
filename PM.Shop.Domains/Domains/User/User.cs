using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.User
{
    public abstract class User
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
