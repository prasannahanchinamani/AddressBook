using AddressBook_Management_System.Model;
using AddressBook_Management_System.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AddressBook_Management_System.Service.DATABASE
{
    public class AddressBookDbService
    {
      
        private int GetOrCreateAddressBookId(string name)
        {
            using SqlConnection con = DbHelper.GetConnection();
            con.Open();

            string select = "SELECT AddressBookId FROM AddressBook WHERE Name=@name";
            SqlCommand cmd = new SqlCommand(select, con);
            cmd.Parameters.AddWithValue("@name", name);

            object result = cmd.ExecuteScalar();
            if (result != null)
                return Convert.ToInt32(result);

            string insert = "INSERT INTO AddressBook VALUES(@name); SELECT SCOPE_IDENTITY();";
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@name", name);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }


        public void SaveAddressBook(string addressBookName, IAddressBook addressBook)
        {
            int bookId = GetOrCreateAddressBookId(addressBookName);

            AddressBookImp book = (AddressBookImp)addressBook;
            List<Contacts> contacts = book.GetAllContacts();

            using SqlConnection con = DbHelper.GetConnection();
            con.Open();

       
            string delete = "DELETE FROM Contacts WHERE AddressBookId=@id";
            SqlCommand delCmd = new SqlCommand(delete, con);
            delCmd.Parameters.AddWithValue("@id", bookId);
            delCmd.ExecuteNonQuery();

         
            foreach (Contacts c in contacts)
            {
                string insert = @"INSERT INTO Contacts
                (AddressBookId,FirstName,LastName,Address,City,State,Zip,Phone,Email)
                VALUES(@aid,@fn,@ln,@addr,@city,@state,@zip,@phone,@email)";

                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@aid", bookId);
                cmd.Parameters.AddWithValue("@fn", c.FirstName);
                cmd.Parameters.AddWithValue("@ln", c.LastName);
                cmd.Parameters.AddWithValue("@addr", c.Address);
                cmd.Parameters.AddWithValue("@city", c.City);
                cmd.Parameters.AddWithValue("@state", c.State);
                cmd.Parameters.AddWithValue("@zip", c.Zip);
                cmd.Parameters.AddWithValue("@phone", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", c.Email);

                cmd.ExecuteNonQuery();
            }
        }


        public void LoadAddressBook(string addressBookName, IAddressBook addressBook)
        {
            AddressBookImp book = (AddressBookImp)addressBook;
            book.ClearContacts();

            using SqlConnection con = DbHelper.GetConnection();
            con.Open();

            string query = @"SELECT c.* FROM Contacts c
                             JOIN AddressBook a ON c.AddressBookId = a.AddressBookId
                             WHERE a.Name=@name";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", addressBookName);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Contacts contact = new Contacts(
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Address"].ToString(),
                    reader["City"].ToString(),
                    reader["State"].ToString(),
                    Convert.ToInt32(reader["Zip"]),
                    Convert.ToInt64(reader["Phone"]),
                    reader["Email"].ToString()
                );

                book.AddContact(contact);
            }
        }
    }
}
