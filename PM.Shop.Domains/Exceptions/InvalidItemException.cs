using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Exceptions
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string message):base(message)
        {
        }
    }
}
