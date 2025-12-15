using AddressBook_Management_System.Service;
using AddressBook_Management_System.Service.DATABASE;
using AddressBook_Management_System.Service.Fileio;
using System;

namespace AddressBook_Management_System.Controller
{
    public class AddressBookController
    {
        private AddressBookSystem system;
        private PersonCSVWrite csv;
        private AddressBookDbService db;

        public AddressBookController()
        {
            system = new AddressBookSystem();
            csv = new PersonCSVWrite();
            db = new AddressBookDbService();
        }

   

        public void CreateAddressBook(string name)
        {
            system.AddAddressBook(name);
        }

        public IAddressBook SelectAddressBook(string name)
        {
            try
            {
                return system.GetAddressBook(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void ShowAddressBooks()
        {
            system.DisplayAddressBooks();
        }


        public void SaveToCsv(string addressBookName)
        {
            try
            {
                IAddressBook book = system.GetAddressBook(addressBookName);
                csv.WriteToCsv(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LoadFromCsv(string addressBookName)
        {
            try
            {
                IAddressBook book = system.GetAddressBook(addressBookName);
                csv.ReadFromCsv(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

   

        public void SaveToDatabase(string addressBookName)
        {
            try
            {
                IAddressBook book = system.GetAddressBook(addressBookName);
                db.SaveAddressBook(addressBookName, book);
                Console.WriteLine("Address Book saved to Database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LoadFromDatabase(string addressBookName)
        {
            try
            {
                IAddressBook book = system.GetAddressBook(addressBookName);
                db.LoadAddressBook(addressBookName, book);
                Console.WriteLine("Address Book loaded from Database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

  

        public void SearchByCity(string city)
        {
            system.SearchByCity(city);
        }

        public void SearchByState(string state)
        {
            system.SearchByState(state);
        }

        public void CountByCityOrState()
        {
            system.CountByCityOrState();
        }
    }
}
