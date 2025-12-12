using AddressBook_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Service
{
    public class AddressBookImp:IAddressBook
    {
        Dictionary<string, Contacts> contacts;

        public AddressBookImp()
        {
            contacts = new Dictionary<string, Contacts>();
        }

        private string GetKey(Contacts c)
        {

            return $"{c.FirstName.ToLower()}_{c.LastName.ToLower()}_{c.Email.ToLower()}";
        }

        void IAddressBook.AddContact(Contacts contact)
        {
              string key = GetKey(contact);
            if (contacts.ContainsKey(key))
            {
                Console.WriteLine("Contact already exists.");
            }
            else
            {
                contacts[key] = contact;
                Console.WriteLine("Contact added successfully.");
            }
        }


        
    }
}
