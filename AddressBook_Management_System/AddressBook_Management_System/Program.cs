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
            Console.WriteLine("\n--- MAIN MENU ---");
            Console.WriteLine("1. Create Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Display Address Books");
            Console.WriteLine("4. Search Person by City");
            Console.WriteLine("5. Search Person by State");
            Console.WriteLine("6. Count Persons by City and State");
            Console.WriteLine("7. Save Address Book to CSV");
            Console.WriteLine("8. Load Address Book from CSV");
            Console.WriteLine("9. Exit");
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
                    if (book != null)
                        ManageContacts(book);
                    break;

                case "3":
                    controller.ShowAddressBooks();
                    break;

                case "4":
                    Console.Write("Enter City: ");
                    controller.SearchByCity(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Enter State: ");
                    controller.SearchByState(Console.ReadLine());
                    break;

                case "6":
                    controller.CountByCityOrState();
                    break;

                case "7":
                    Console.Write("Enter Address Book Name to SAVE: ");
                    controller.SaveToCsv(Console.ReadLine());
                    break;

                case "8":
                    Console.Write("Enter Address Book Name to LOAD: ");
                    controller.LoadFromCsv(Console.ReadLine());
                    break;

                case "9":
                    exit = true;
                    Console.WriteLine("Exiting Address Book System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void ManageContacts(IAddressBook addressBook)
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("\n--- CONTACT MENU ---");
            Console.WriteLine("1. Add Contact");
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

                    default:
                        Console.WriteLine("Invalid choice.");
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

        string firstName = v.ValidateFirstName();
        string lastName = v.ValidateLastName();
        string address = v.ValidateAddress();

        Console.Write("Enter City: ");
        string city = Console.ReadLine();

        string state = v.ValidateState();
        int zip = v.ValidateZip();
        long phone = v.ValidatePhoneNumber();
        string email = v.ValidateEmail();

        return new Contacts(firstName, lastName, address, city, state, zip, phone, email);
    }

    static (string, string) GetNameInput(string action)
    {
        Console.Write("Enter First Name to " + action + ": ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name to " + action + ": ");
        string lastName = Console.ReadLine();

        return (firstName, lastName);
    }
}
