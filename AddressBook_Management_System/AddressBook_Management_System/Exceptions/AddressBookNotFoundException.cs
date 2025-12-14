using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Exceptions
{
   public class AddressBookNotFoundException:Exception
    {
        public AddressBookNotFoundException(string message) : base(message) { }
    }
}
