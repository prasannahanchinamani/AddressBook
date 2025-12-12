using AddressBook_Management_System.Exceptions;
using AddressBook_Management_System.Model;
using AddressBook_Management_System.Service;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address Book");

        IAddressBook addressBook = new AddressBookImp();
        bool exit = false;

        while (!exit)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Contacts newContact = GetContactDetails();
                        addressBook.AddContact(newContact);
                        break;

                    case "2":
                        addressBook.DisplayContacts();
                        break;

                    case "3":
                        var (editFirst, editLast) = GetNameInput("edit");
                        addressBook.EditContact(editFirst, editLast);
                        break;

                    case "4":
                        var (delFirst, delLast) = GetNameInput("delete");
                        addressBook.DeleteContact(delFirst, delLast);
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting Address Book. Thank You!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (ContactNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Add Contact");
        Console.WriteLine("2. Display Contacts");
        Console.WriteLine("3. Edit Contact");
        Console.WriteLine("4. Delete Contact");
        Console.WriteLine("5. Exit");
        Console.Write("Enter choice: ");
    }

    static Contacts GetContactDetails()
    {
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Address: ");
        string address = Console.ReadLine();

        Console.Write("Enter City: ");
        string city = Console.ReadLine();

        Console.Write("Enter State: ");
        string state = Console.ReadLine();

        Console.Write("Enter Zip: ");
        int zip = int.Parse(Console.ReadLine());

        Console.Write("Enter Phone Number: ");
        long phoneNumber = long.Parse(Console.ReadLine());

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        return new Contacts(firstName, lastName, address, city, state, zip, phoneNumber, email);
    }

    static (string firstName, string lastName) GetNameInput(string action)
    {
        Console.Write($"Enter First Name of contact to {action}: ");
        string firstName = Console.ReadLine();

        Console.Write($"Enter Last Name of contact to {action}: ");
        string lastName = Console.ReadLine();

        return (firstName, lastName);
    }
}