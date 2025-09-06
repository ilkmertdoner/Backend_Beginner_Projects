using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserAuthSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();

            while(true)
            {
                string choice = Menu("Welcome to the User Authentication System. Please select an option to continue: ");

                if (choice == "1")
                {
                    RegisterUser(users);
                }

                else if (choice == "2")
                {
                    int RemainingAttempts = 3;

                    AttemptLogin(users, ref RemainingAttempts);
                }

                else if (choice == "3")
                {
                    Console.WriteLine("Exiting the system.");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.\n");
                }
            }
        }
        
        static string Menu(string prompt)
        {
            while (true) 
            { 
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write(prompt);
                string choices = Console.ReadLine();
                
                if(choices == "1" || choices == "2" || choices == "3")
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    return choices;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                
            }
        }
        
        static (string name, string password) Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            return (username, password);
        }

        private static void RegisterUser(List<User> users)
        {
            while (true)
            {
                var (username, password) = Register();
                User newUser = new User(username, password);
                bool PasswordControl = newUser.ValidatePassword(password);

                if (PasswordControl == true)
                {
                    users.Add(newUser);
                    break;
                }

                continue;
            }

            Console.WriteLine("Registration successful!");
            Console.WriteLine("-------------------------------------");
        }

        private static int AttemptLogin(List<User> users, ref int RemainingAttempts)
        {
            while (RemainingAttempts > -1)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                bool loginSuccess = false;

                foreach (var user in users)
                {

                    if (user.Login(username, password))
                    {
                        Console.WriteLine("Welcome, " + user.Username + "!");
                        Console.WriteLine("------------------------------------------------");
                        loginSuccess = true;
                        break;
                    }

                }
                
                if (loginSuccess == true) break;

                RemainingAttempts--;

                Console.WriteLine($"Invalid Credentials. You have {RemainingAttempts} attempts left.");
                Console.WriteLine("------------------------------------------------");

                if (RemainingAttempts == 0)
                {
                    Console.WriteLine("Too many failed attempts. Exiting the system.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
                }

            }

            return RemainingAttempts;
        }

        
    }
}

    class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool ValidatePassword(string password)
        {
            if (password.Length < 6 || !password.Any(char.IsLetter))
            {
                Console.WriteLine("Password must be at least 6 characters long and contain at least one letter.");
                return false;
            }
            else
            {
                return true;
            }
        }
        
        
       
        public bool Login(string username, string password)
        {

            if (Username == username && Password == password)
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }
        } 
    }





