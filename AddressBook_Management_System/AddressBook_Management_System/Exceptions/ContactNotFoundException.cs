using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Exceptions
{
    internal class ContactNotFoundException : Exception
    {
      public ContactNotFoundException(string message) :base( message) { }
    }
}
