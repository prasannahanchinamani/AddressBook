using System.Data.SqlClient;

namespace AddressBook_Management_System.Service.DATABASE
{
    public static class DbHelper
    {
        public static string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Database=AddressBookDB;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
