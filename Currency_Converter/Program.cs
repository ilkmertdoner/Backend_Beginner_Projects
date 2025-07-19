using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Currency_Converter
{
    internal class Program
    {
        static Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
            { "USD", 1.0 },
            { "EUR", 0.91 },
            { "GBP", 0.79 },
            { "JPY", 157.80 },
            { "AUD", 40.23 },
            { "TRY", 40.23 }
        };

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Welcome to the Currency Converter!");
                Console.WriteLine("Press 1 to start the application");
                Console.WriteLine("Press 2 to exit the application");
                Console.Write("Enter your selection: ");

                string selection = Console.ReadLine();

                if (selection == "2")
                {
                    isRunning = false;
                    Console.WriteLine("Exiting the application.");
                    Thread.Sleep(1500); 
                    break;
                }
                else if (selection != "1")
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                    continue;
                }

                double amount = GetDoubleInput("Please enter the amount you want to exchange: ");

                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Available currencies:");
                DisplayCurrencies();

                string fromCurrency = GetCurrencyInput("Please select a currency to convert FROM: ");
                string toCurrency = GetCurrencyInput("Please select a currency to convert TO: ");

                double convertedAmount = ConvertCurrency(amount, fromCurrency, toCurrency);
                Console.WriteLine($"Result: {amount} {fromCurrency} = {convertedAmount:F3} {toCurrency}");
                Console.WriteLine();
            }
        }

        static void DisplayCurrencies()
        {
            int index = 1;
            foreach (var currency in exchangeRates.Keys)
            {
                Console.WriteLine($"{index}. {currency}");
                index++;
            }
        }

        static string GetCurrencyInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper();

                if (exchangeRates.ContainsKey(input)) return input;

                Console.WriteLine("Invalid currency code. Please try again.");
            }
        }

        static double GetDoubleInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double result) && result > 0) return result;

                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            }
        }

        static double ConvertCurrency(double amount, string fromCurrency, string toCurrency)
        {
            double fromRate = exchangeRates[fromCurrency];
            double toRate = exchangeRates[toCurrency];

            double amountInUsd = amount / fromRate;
            double convertedAmount = amountInUsd * toRate;

            return Math.Round(convertedAmount, 3);
        }
    }
}
