using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Model
{
    public class Contacts:IComparable<Contacts>
    {
        // Private fields
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private int zip;
        private long phoneNumber;
        private string email;

        // Public properties (encapsulation)
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public int Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public long PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public Contacts(string firstName, string lastName, string address,
                        string city, string state, int zip, long phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        public override bool Equals(object obj)
{
    if (obj == null || !(obj is Contacts))
        return false;

    Contacts other = (Contacts)obj;

    return this.FirstName.Equals(other.FirstName, StringComparison.OrdinalIgnoreCase)
        && this.LastName.Equals(other.LastName, StringComparison.OrdinalIgnoreCase);
}

public override int GetHashCode()
{
    return (FirstName + LastName).ToLower().GetHashCode();
}


        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\n" +
                   $"Address: {Address}, {City}, {State}, {Zip}\n" +
                   $"Phone: {PhoneNumber}\n" +
                   $"Email: {Email}";
        }


        public int CompareTo(Contacts other)
        {
            if (other == null) return 1;

            //  First Name
            int result = this.FirstName.CompareTo(other.FirstName);
            if (result != 0) return result;

            //Last Name
            result = this.LastName.CompareTo(other.LastName);
            if (result != 0) return result;

            //  Sort by State
            result = this.State.CompareTo(other.State);
            if (result != 0) return result;

            // Sort by Zip
            return this.Zip.CompareTo(other.Zip);
        }

    }
}



