using AddressBook_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Service
{
    internal interface IAddressBook
    {
        void AddContact(Contacts contact);
    }
}
