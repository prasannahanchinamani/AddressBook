using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Service
{
        public class AddressBookSystem
        {
            private Dictionary<string, IAddressBook> addressBooks;

            public AddressBookSystem()
            {
                addressBooks = new Dictionary<string, IAddressBook>();
            }

            public void AddAddressBook(string name)
            {
                if (addressBooks.ContainsKey(name))
                {
                    Console.WriteLine("Address Book already exists.");
                    return;
                }

                addressBooks[name] = new AddressBookImp();
                Console.WriteLine($"Address Book '{name}' created successfully.");
            }

            public IAddressBook GetAddressBook(string name)
            {
                if (!addressBooks.ContainsKey(name))
                    throw new Exception("Address Book not found.");

                return addressBooks[name];
            }

            public void DisplayAddressBooks()
            {
                if (addressBooks.Count == 0)
                {
                    Console.WriteLine("No Address Books available.");
                    return;
                }

                Console.WriteLine("Available Address Books:");
                foreach (string name in addressBooks.Keys)
                {
                    Console.WriteLine($"- {name}");
                }
            }
        }
    }