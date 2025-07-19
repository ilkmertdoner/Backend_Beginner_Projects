using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Number_Guessing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            
            while (isRunning)
            {
                Random random = new Random();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Welcome to the Number Guessing Game!");
                Console.WriteLine("Press any key to Start");
                Console.WriteLine("Press 'q' to quit the game at any time.");
                string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();

                if (choice == "q")
                {
                    isRunning = false;
                    Console.WriteLine("Thank you for playing! Goodbye!");
                    Thread.Sleep(2000);
                    break;
                }

                var (lives, maxNumber) = DifficultySelection();
                Console.WriteLine($"You have {lives} tries to guess a number between 0 and {maxNumber}.");

                int numberToGuess = random.Next(0, maxNumber + 1);
                int tries = lives;

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("A number has been generated. Start guessing!");

                while (lives > -1)
                {
                    if (lives == 0)
                    {
                        Console.WriteLine("You have no more lives left. Game Over!");
                        Console.WriteLine($"The number was: {numberToGuess}");
                        break;
                    }

                    Console.WriteLine($"You have {lives} tries left. Please enter your guess: ");
                    int input = int.Parse(Console.ReadLine());

                    if (input == numberToGuess)
                    {
                        Console.WriteLine("Congratulations! You've guessed the number correctly!");
                        Thread.Sleep(2000);
                        break;
                    }
                    else if (input < numberToGuess)
                    {
                        Console.WriteLine("Your guess is too low. Try again.");
                        lives--;
                    }
                    else
                    {
                        Console.WriteLine("Your guess is too high. Try again.");
                        lives--;
                    }
                }

            }
        }

        static (int lives, int MaxNumber) DifficultySelection()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Please choose a difficulty level:");
                Console.WriteLine("1-) Easy (10 Tries and the number is between 1-20)\n2-) Normal (5 Tries and the number is between 1-50)\n" +
                "3-) Hard (3 Tries and the number is between 1-100)\n ");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if ("123".Contains(choice) && choice.Length == 1)
                {
                    if(choice == "1")
                    {
                        return (10,20);
                    }
                    else if (choice == "2")
                    {
                        return (5,50);
                    }
                    else if (choice == "3")
                    {
                        return (3,100);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }
            }
        }
    }
}
