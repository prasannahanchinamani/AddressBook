using AddressBook_Management_System.Model;
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
            addressBooks = new Dictionary<string, IAddressBook>(
                StringComparer.OrdinalIgnoreCase
            );
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
        public void SearchByCity(string city)
        {
            var result = addressBooks.Values
                .SelectMany(b => ((AddressBookImp)b).GetAllContacts())
                .Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No persons found in this city.");
                return;
            }

            foreach (var c in result)
                Console.WriteLine(c);
        }

        public void SearchByState(string state)
        {
           List<Contacts> result = addressBooks.Values
                .SelectMany(b => ((AddressBookImp)b).GetAllContacts())
                .Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No persons found in this state.");
                return;
            }

            foreach (var c in result)
                Console.WriteLine(c);
        }
        public void CountByCityOrState()
        {
            Dictionary<string, int> result = addressBooks.Values
                .SelectMany(b => ((AddressBookImp)b).GetAllContacts())
                .GroupBy(c => c.City)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (KeyValuePair<string, int> x in result)
            {
                Console.WriteLine($"City: {x.Key} : People {x.Value}");
            }

            Dictionary<string, int> result1 = addressBooks.Values
                .SelectMany(b => ((AddressBookImp)b).GetAllContacts())
                .GroupBy(c => c.State)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (KeyValuePair<string, int> x in result1)
            {
                Console.WriteLine($"State: {x.Key} : People {x.Value}");
            }
        }


    }
}