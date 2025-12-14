using AddressBook_Management_System.Exceptions;
using AddressBook_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook_Management_System.Service
{
    public class AddressBookImp : IAddressBook
    {
        private Dictionary<string, Contacts> contacts;

        public AddressBookImp()
        {
            contacts = new Dictionary<string, Contacts>();
        }

        private string GetKey(Contacts c)
        {
            return $"{c.FirstName.ToLower()}_{c.LastName.ToLower()}_{c.Email.ToLower()}";
        }
        public void AddContact(Contacts contact)
        {
            bool isDuplicate = contacts.Values.Any(c => c.Equals(contact));

            if (isDuplicate)
            {
                Console.WriteLine("Duplicate contact found. Contact not added.");
                return;
            }
            

            string key = GetKey(contact);
            contacts[key] = contact;
            List<Contacts> sorted = contacts.Values.ToList();
            sorted.Sort();
            Console.WriteLine("Contact added successfully.");
        }



        public void EditContact(string firstName, string lastName)
        {
            string keyMatch = contacts
                .Where(kvp =>
                    kvp.Value.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    kvp.Value.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Key)
                .FirstOrDefault();

            if (keyMatch == null)
                throw new ContactNotFoundException($"Contact {firstName} {lastName} not found.");

            Contacts editContact = contacts[keyMatch];
            ValidateInput validator = new ValidateInput();

            Console.WriteLine("Do you want to edit name (y/n)?");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                editContact.FirstName = validator.ValidateFirstName();
                editContact.LastName = validator.ValidateLastName();
            }

            editContact.Address = validator.ValidateAddress();
            Console.Write("Enter City: ");
            editContact.City = Console.ReadLine();
            editContact.State = validator.ValidateState();
            editContact.Zip = validator.ValidateZip();
            editContact.PhoneNumber = validator.ValidatePhoneNumber();
            editContact.Email = validator.ValidateEmail();

            contacts.Remove(keyMatch);
            contacts[GetKey(editContact)] = editContact;

            Console.WriteLine("Contact updated successfully.");
        }

        public void DeleteContact(string firstName, string lastName)
        {
            string keyMatch = contacts
                .Where(kvp =>
                    kvp.Value.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    kvp.Value.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Key)
                .FirstOrDefault();

            if (keyMatch == null)
                throw new ContactNotFoundException($"Contact {firstName} {lastName} not found.");

            contacts.Remove(keyMatch);
            Console.WriteLine($"Contact {firstName} {lastName} deleted successfully.");
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts to display.");
                return;
            }

            foreach (Contacts contact in contacts.Values)
            {
                Console.WriteLine(contact);
            }
        }
        public List<Contacts> GetAllContacts()
        {
            return contacts.Values.ToList();
        }

            public void ClearContacts()
        {
            contacts.Clear();
        }


    }
}
