using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class Program
    {
        static PaymentMethod paymentMethod;
        static int balance = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                string option = Menu("Welcome To The Banking System Please Select Option");

                if (option == "1")
                {
                    Console.Clear();
                    DepositMoney();
                }

                else if (option == "2")
                {
                    Console.Clear();
                    WithdrawMoney();
                }
                else if (option == "3")
                {
                    Console.Clear();
                    TransferMoney();
                }
                else if (option == "4")
                {
                    Console.Clear();
                    ShowBalance();
                }
                else if (option == "5")
                {
                    Console.WriteLine("Exiting the system. Goodbye!");
                    break;
                }
            }
        }

        static string Menu(string message)
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine(message);
                Console.WriteLine("1-) Deposit Money");
                Console.WriteLine("2-) Withdraw Money");
                Console.WriteLine("3-) Transfer Money");
                Console.WriteLine("4-) Show Balance");
                Console.WriteLine("5-) Exit");

                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int option);

                Console.WriteLine("-------------------------------------------------------");

                if (!isNumber || option < 1 || option > 5)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue;
                }
                
                return input;
            }
        }

        static string PaymentType(string transactionType)
        {
            while (true)
            {
                Console.WriteLine("Please select a payment type");

                if (transactionType == "Deposit")
                {
                    Console.WriteLine("1-) Cash");
                    Console.WriteLine("2-) Exit");
                }
                else if (transactionType == "Transfer")
                {
                    Console.WriteLine("1-) Cash");
                    Console.WriteLine("2-) Credit Card");
                    Console.WriteLine("3-) EFT");
                    Console.WriteLine("4-) Exit");
                }
                else if(transactionType == "Withdraw")
                {
                    Console.WriteLine("1-) Cash");
                    Console.WriteLine("2-) Credit Card");
                    Console.WriteLine("3-) Exit");
                }

                Console.Write("Select a payment type: ");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int option);

                if (transactionType == "Withdraw")
                {
                    if (!isNumber || option < 1 || option > 3)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        Console.WriteLine("-------------------------------------------------------");
                        continue;
                    }
                }
                else if (transactionType == "Deposit")
                {
                    if (!isNumber || option < 1 || option > 2)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 2.");
                        Console.WriteLine("-------------------------------------------------------");
                        continue;
                    }
                }
                else
                {
                    if (!isNumber || option < 1 || option > 4)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        Console.WriteLine("-------------------------------------------------------");
                        continue;
                    }
                }

                return input;
            }
        }


        static void DepositMoney()
        {
            Console.Clear();
            string Type = PaymentType("Deposit");

            if (Type == "3") return;

            Console.Write("Please select a amount to transfer: ");
            int amount = int.Parse(Console.ReadLine());

            if (Type == "1")
            {
                Console.Clear();
                paymentMethod = new Cash();
                paymentMethod.ProcessPayment(amount, "Deposited");
                balance += amount;
            }
        }

        static void WithdrawMoney()
        {
            Console.Clear();
            string Type = PaymentType("Withdraw");
            
            if (Type == "3") return;

            Console.Write("Please select a amount to transfer: ");
            int amount = int.Parse(Console.ReadLine());

            if(amount > balance)
            {
                Console.WriteLine("Insufficient balance for this withdrawal.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                return;
            }

            if (Type == "1")
            {
                Console.Clear();
                paymentMethod = new Cash();
                paymentMethod.ProcessPayment(amount, "Withdrawn");
                balance -= amount;
            }
            else if (Type == "2")
            {
                Console.Clear();
                paymentMethod = new CreditCard();
                paymentMethod.ProcessPayment(amount, "Withdrawn");
                balance -= amount;
            }
        }
        
        static void TransferMoney()
        {
            Console.Clear();
            string Type = PaymentType("Transfer");
            if (Type == "4") return;
            Console.Write("Please select a amount to transfer: ");
            int amount = int.Parse(Console.ReadLine());

            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance for this withdrawal.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                return;
            }

            if (Type == "1")
            {
                Console.Clear();
                paymentMethod = new Cash();
                paymentMethod.ProcessPayment(amount, "Transferred");
                balance -= amount;
            }
            else if (Type == "2")
            {""
                Console.Write("Please enter the Card Number of the target: ");
                string Number = Console.ReadLine();
                Console.Clear();

                paymentMethod = new CreditCard();
                paymentMethod.Number = Number;
                paymentMethod.ProcessPayment(amount, "Transferred");
                balance -= amount;
            }
            else if (Type == "3")
            {
                Console.Write("Please enter the name of the target: ");
                string Name = Console.ReadLine();
                Console.Write("Please enter the IBAN of the target: ");
                string Number = Console.ReadLine();
                Console.Clear();

                paymentMethod = new EFT();
                paymentMethod.Name = Name;
                paymentMethod.Number = Number;
                paymentMethod.ProcessPayment(amount, "Transferred");
                balance -= amount;
            }
        }

        static void ShowBalance()
        {
            Console.Clear();
            Console.WriteLine($"Your current balance is: {balance} USD");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}
