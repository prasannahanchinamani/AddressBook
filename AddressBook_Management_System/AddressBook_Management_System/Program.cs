using System;
using AddressBook_Management_System.Model;
using AddressBook_Management_System.Service;
using AddressBook_Management_System.Exceptions;
using AddressBook_Management_System.Controller;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address Book System");

        AddressBookController controller = new AddressBookController();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n1. Create Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Display Address Books");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Address Book Name: ");
                    controller.CreateAddressBook(Console.ReadLine());
                    break;

                case "2":
                    Console.Write("Enter Address Book Name: ");
                    IAddressBook book = controller.SelectAddressBook(Console.ReadLine());
                    ManageContacts(book);
                    break;

                case "3":
                    controller.ShowAddressBooks();
                    break;

                case "4":
                    exit = true;
                    break;
            }
        }
    }

    static void ManageContacts(IAddressBook addressBook)
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("\n1. Add Contact");
            Console.WriteLine("2. Display Contacts");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Back");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        addressBook.AddContact(GetContactDetails());
                        break;

                    case "2":
                        addressBook.DisplayContacts();
                        break;

                    case "3":
                        (string ef, string el) = GetNameInput("edit");
                        addressBook.EditContact(ef, el);
                        break;

                    case "4":
                        (string df, string dl) = GetNameInput("delete");
                        addressBook.DeleteContact(df, dl);
                        break;

                    case "5":
                        back = true;
                        break;
                }
            }
            catch (ContactNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static Contacts GetContactDetails()
    {
        ValidateInput v = new ValidateInput();

        string f = v.ValidateFirstName();
        string l = v.ValidateLastName();
        string a = v.ValidateAddress();

        Console.Write("Enter City: ");
        string c = Console.ReadLine();

        string s = v.ValidateState();
        int z = v.ValidateZip();
        long p = v.ValidatePhoneNumber();
        string e = v.ValidateEmail();

        return new Contacts(f, l, a, c, s, z, p, e);
    }

    static (string, string) GetNameInput(string action)
    {
        Console.Write("Enter First Name to " + action + ": ");
        string f = Console.ReadLine();

        Console.Write("Enter Last Name to " + action + ": ");
        string l = Console.ReadLine();

        return (f, l);
    }
}
