using System;
using System.Collections.Generic;
using System.IO;
using AddressBook_Management_System.Model;
using AddressBook_Management_System.Service;

namespace AddressBook_Management_System.Service.Fileio
{
    public class PersonCSVWrite
    {
        private string path = @"C:\Users\User\Desktop\C#ProJects\AddressBook_Management_System\AddressBook_Management_System\Service\Fileio";
        private string filePath;

        public PersonCSVWrite()
        {
            Directory.CreateDirectory(path);   
            filePath = Path.Combine(path, "Person.csv");
        }

        
        public void WriteToCsv(IAddressBook addressBook)
        {
            AddressBookImp book = (AddressBookImp)addressBook;
            List<Contacts> contacts = book.GetAllContacts();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                
                writer.WriteLine("FirstName,LastName,Address,City,State,Zip,Phone,Email");

                foreach (Contacts c in contacts)
                {
                    writer.WriteLine(
                        $"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State}," +
                        $"{c.Zip},{c.PhoneNumber},{c.Email}"
                    );
                }
            }

            if (contacts.Count == 0)
                Console.WriteLine("Address Book empty. CSV file created with headers only.");
            else
                Console.WriteLine("Contacts successfully written to CSV.");
        }

        public void ReadFromCsv(IAddressBook addressBook)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("CSV file not found.");
                return;
            }

            AddressBookImp book = (AddressBookImp)addressBook;
            book.ClearContacts(); 

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length <= 1)
            {
                Console.WriteLine("CSV file contains no contact data.");
                return;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] d = lines[i].Split(',');

                Contacts contact = new Contacts(
                    d[0], d[1], d[2], d[3], d[4],
                    int.Parse(d[5]),
                    long.Parse(d[6]),
                    d[7]
                );

                book.AddContact(contact);
            }

            Console.WriteLine("Contacts successfully loaded from CSV.");
        }
    }
}
