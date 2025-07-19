using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz_Application
{
    internal class Program
    {
        static string[] questions =
        {
            "1-) What is the largest planet in our Solar System?",
            "2-) Who wrote the play Romeo and Juliet?",
            "3-) What is the chemical symbol for water?",
            "4-) Which continent is known as the ‘Dark Continent",
            "5-) What does CPU stand for in computers"
        };

        static string[] choices =
        {
            "1-) A-) Earth B-) Mars C-) Jupiter D-) Venus E-) Saturn",
            "2-) A-) William Shakespeare B-) Charles Dickens C-) Leo Tolstoy D-) Mark Twain E-) Jane Austen",
            "3-) A-) H2O B-) CO2 C-) NaCl D-) O2 E-) HO2",
            "4-) A-) Asia B-) Africa C-) Europe D-) Australia E-) South America",
            "5-) A-) Central Performance Unit B-) Computer Personal Unit C-) Central Processing Unit D-) Control Program Unit E-) Computer Power Utility"
        };
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Welcome to the Quiz Application!");
                Console.WriteLine($"Press {"1"} to Start Quiz");
                Console.WriteLine($"Press {"2"} to Exit Application");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "2")
                {
                    isRunning = false;
                    Console.WriteLine("Exiting the application.");
                    Thread.Sleep(1500);
                    break;
                }
                else if (choice != "1")
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                string[] correctAnswers = {"C", "A", "A", "B", "C"};
                string[] userAnswers = new string[questions.Length];

                for(int i = 0; i < questions.Length; i++)
                {
                    string answer = DisplayQuestion(questions[i], choices[i]);
                    userAnswers[i] = answer;
                }

                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Quiz Completed here are your results:");
                string result = CalculateScore(correctAnswers, userAnswers);
                Console.WriteLine($"Your score: {result} out of {questions.Length} questions.");
                Console.WriteLine("-----------------------------------------------------");
                Thread.Sleep(2000);
            }
        }

        static string DisplayQuestion(string question, string choices)
        {
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine(question);
                Console.WriteLine(choices);

                string answer = Console.ReadLine().ToUpper();

                if ("ABCDE".Contains(answer) && answer.Length == 1)
                {
                    Console.WriteLine($"You selected: {answer}");
                    return answer; 
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }

        static string CalculateScore(string[] correctAnswer, string[] userAnswer)
        {
            int score = 0;
            for (int i = 0; i < correctAnswer.Length; i++)
            {
                if (correctAnswer[i] == userAnswer[i])
                {
                    score++;
                }
            }
            return score.ToString();
        }

    }
}
