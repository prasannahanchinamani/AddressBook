using AddressBook_Management_System.Exceptions;
using AddressBook_Management_System.Model;
using System;
using System.Collections.Generic;

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

        void IAddressBook.EditContact(string firstName, string lastName)
        {
            var keyMatch = contacts
               .Where(kvp => kvp.Value.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                             kvp.Value.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
               .Select(kvp => kvp.Key)
               .FirstOrDefault();

            if (keyMatch != null)
            {
                Contacts editcontact = contacts[keyMatch];
                ValidateInput validator = new ValidateInput();

                Console.WriteLine("Do you want to edit name (y/n)?");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y")
                {
                    editcontact.FirstName = validator.ValidateFirstName();
                    editcontact.LastName = validator.ValidateLastName();
                }

                editcontact.Address = validator.ValidateAddress();
                Console.Write("Enter City: ");
                editcontact.City = Console.ReadLine();
                editcontact.State = validator.ValidateState();
                editcontact.Zip = validator.ValidateZip();
                editcontact.PhoneNumber = validator.ValidatePhoneNumber();
                editcontact.Email = validator.ValidateEmail();

                contacts.Remove(keyMatch);
                string newKey = GetKey(editcontact);
                contacts[newKey] = editcontact;

                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                throw new ContactNotFoundException($"Contact {firstName} {lastName} not found.");
            }

        }

        void IAddressBook.DeleteContact(string firstName, string lastName)
        {
            var keyMatch = contacts
                  .Where(kvp => kvp.Value.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                                kvp.Value.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                  .Select(kvp => kvp.Key)
                  .FirstOrDefault();

            if (keyMatch != null)
            {
                contacts.Remove(keyMatch);
                Console.WriteLine($"Contact {firstName} {lastName} deleted successfully.");
            }
            else
            {
                throw new ContactNotFoundException($"Contact {firstName} {lastName} not found.");
            }
        }

        void IAddressBook.DisplayContacts()
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
    }
}
