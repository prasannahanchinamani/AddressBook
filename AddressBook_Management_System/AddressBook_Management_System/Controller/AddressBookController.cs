using AddressBook_Management_System.Service;

namespace AddressBook_Management_System.Controller
{
    public class AddressBookController
    {
        private AddressBookSystem system;

        public AddressBookController()
        {
            system = new AddressBookSystem();
        }

        public void CreateAddressBook(string name)
        {
            system.AddAddressBook(name);
        }

        public IAddressBook SelectAddressBook(string name)
        {
            return system.GetAddressBook(name);
        }

        public void ShowAddressBooks()
        {
            system.DisplayAddressBooks();
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
