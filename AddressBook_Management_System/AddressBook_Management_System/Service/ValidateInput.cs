using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook_Management_System.Service
{
    internal class ValidateInput
    {
            public string ValidateFirstName()
            {
                string pattern = @"^[A-Za-z][a-zA-Z]{2,}$";
                while (true)
                {
                    Console.Write("Enter First Name: ");
                    string firstNameV = Console.ReadLine();

                    if (Regex.IsMatch(firstNameV, pattern))
                        return firstNameV;
                    else
                        Console.WriteLine("Invalid First Name. Must be at least 3 letters.");
                }
            }

            public string ValidateLastName()
            {
                string pattern = @"^[A-Za-z][a-zA-Z]{1,}$";
                while (true)
                {
                    Console.Write("Enter Last Name: ");
                    string lastNameV = Console.ReadLine();

                    if (!string.IsNullOrEmpty(lastNameV) || Regex.IsMatch(lastNameV, pattern))
                        return lastNameV;
                    else
                        Console.WriteLine("Invalid");
                }
            }

            public string ValidateAddress()
            {
                string pattern = @"^[A-Za-z0-9.+*#]{3,}$";
                while (true)
                {
                    Console.Write("Enter Address: ");
                    string addressV = Console.ReadLine();

                    if (Regex.IsMatch(addressV, pattern))
                        return addressV;
                    else
                        Console.WriteLine("Invalid Address. Must be at least 3 characters.");
                }
            }

            public string ValidateEmail()
            {
                string pattern = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                while (true)
                {
                    Console.Write("Enter Email: ");
                    string emailV = Console.ReadLine();

                    if (Regex.IsMatch(emailV, pattern))
                        return emailV;
                    else
                        Console.WriteLine("Invalid Email format. Try again...");
                }
            }

            public string ValidateState()
            {
                string pattern = @"^[A-Za-z]{3,}$";
                while (true)
                {
                    Console.Write("Enter State: ");
                    string stateV = Console.ReadLine();

                    if (Regex.IsMatch(stateV, pattern))
                        return stateV;
                    else
                        Console.WriteLine("Invalid State. Must be at least 3 letters.");
                }
            }

            public int ValidateZip()
            {
                string pattern = @"^[0-9]{5,6}$";
                while (true)
                {
                    Console.Write("Enter Zip: ");
                    string zipV = Console.ReadLine();

                    if (Regex.IsMatch(zipV, pattern))
                        return int.Parse(zipV);
                    else
                        Console.WriteLine("Invalid Zip. Must be 5 or 6 digits.");
                }
            }

            public long ValidatePhoneNumber()
            {
                string pattern = @"^[0-9]{10}$";
                while (true)
                {
                    Console.Write("Enter Phone Number: ");
                    string phoneV = Console.ReadLine();

                    if (Regex.IsMatch(phoneV, pattern))
                        return long.Parse(phoneV);
                    else
                        Console.WriteLine("Invalid Phone Number. Must be 10 digits.");
                }
            }
    }
 }

