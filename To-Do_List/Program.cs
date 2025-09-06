using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace To_Do_List
{
    internal class Program
    {
        struct ToDoItem
        {
            public int Id;
            public string Title;
            public string Description;
            public string DueDate;
            public bool IsCompleted;
            public void print()
            {
                string status = IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{Id}. {Title}, {Description}, {DueDate}, {status}");
            }
        }
        
        static void Main(string[] args)
        {
            ToDoItem[] item = new ToDoItem[20];
            int counter = 0;

            while (true)
            {
                Console.WriteLine("----------------------------------------");

                for (int i = 0; i < counter; i++)
                {
                    item[i].print();
                }

                Console.WriteLine("----------------------------------------");
                string choice = Menu("Please select an option: ");

                if (choice == "1")
                {
                    bool flowControl = ToDoItemManager.AddToDoItem(item, ref counter);

                    if (!flowControl)
                    {
                        continue;
                    }
                }

                else if (choice == "2")
                {
                    bool flowControl = ToDoItemManager.MarkToDoItemAsCompleted(item, ref counter);
                    
                    if (!flowControl)
                    {
                        continue;
                    }

                }

                else if (choice == "3")
                {
                    bool flowControl = ToDoItemManager.DeleteToDoItem(item, ref counter);
                    
                    if (!flowControl)
                    {
                        continue;
                    }
                }

                else if (choice == "4")
                {
                    Console.WriteLine("Exiting the To-Do List application.");
                    Thread.Sleep(2000);
                    break;
                }

            }
        }

        static string Menu(string message)
        {
            Console.WriteLine("To-Do List Menu:");
            Console.WriteLine("1. Add To-Do Item");
            Console.WriteLine("2. Mark To-Do Item as Completed");
            Console.WriteLine("3. Select a To-Do Item to Delete");
            Console.WriteLine("4. Exit");
            Console.Write(message);

            string options;
            while (true)
            {
                options = Console.ReadLine();
                if (options == "1" || options == "2" || options == "3" || options == "4")
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid choice. Please select a valid option (1-4): ");
                }
            }
            
            Console.WriteLine("----------------------------------------");
            return options;

        }

        static class ToDoItemManager
        {
            public static bool AddToDoItem(ToDoItem[] item, ref int counter)
            {
                while (true)
                {
                    ToDoItem newItem = new ToDoItem();

                    Console.WriteLine("Note: The maximum number of To-Do items is 20. If you add a new item, the oldest one will be removed.");
                    newItem.Id = counter + 1;
                    Console.Write("Enter the title of the To-Do item: ");
                    newItem.Title = Console.ReadLine();
                    Console.Write("\nEnter the description of the To-Do item: ");
                    newItem.Description = Console.ReadLine();
                    Console.Write("\nEnter the due date (in days from today): ");
                    string dueDateInput = Console.ReadLine();
                    newItem.IsCompleted = false;

                    if (!dueDateInput.All(char.IsDigit))
                    {
                        Console.WriteLine("Please enter a valid due date.");
                        Console.WriteLine("----------------------------------------");
                        continue;
                    }

                    else
                    {
                        newItem.DueDate = dueDateInput;
                    }

                    if (counter < 20)
                    {
                        item[counter] = newItem;
                        counter++;
                    }

                    else if (counter == 20)
                    {
                        for (int i = 1; i < 20; i++)
                        {
                            item[i - 1] = item[i];
                        }
                    }

                    return true;
                }
            }
            
            public static bool MarkToDoItemAsCompleted(ToDoItem[] item, ref int counter)
            {
                for (int i = 0; i < counter; i++)
                {
                    item[i].print();
                }

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Note: Selecting a completed item will mark it as uncompleted.");
                Console.Write("Enter the ID of the To-Do item to mark as completed: ");
                int input = int.Parse(Console.ReadLine());

                if (input < 1 || input > counter)
                {
                    Console.WriteLine("Invalid ID. Please try again.");
                    return false;
                }
                else if (item[input - 1].IsCompleted)
                {
                    Console.WriteLine("This item is already completed. Marking it as uncompleted.");
                    item[input - 1].IsCompleted = false;
                    return false;
                }

                item[input - 1].IsCompleted = true;
                return true;
            }
            
            public static bool DeleteToDoItem(ToDoItem[] item, ref int counter)
            {
                for (int i = 0; i < counter; i++)
                {
                    item[i].print();
                }
                
                Console.WriteLine("----------------------------------------");

                Console.Write("Select a To-Do item to delete by its ID: ");
                int input = int.Parse(Console.ReadLine());

                if (input < 1 || input > counter)
                {
                    Console.WriteLine("Invalid ID. Please try again.");
                    return false;
                }

                for (int i = input - 1; i < counter - 1; i++)
                {
                    item[i] = item[i + 1];
                    item[i].Id = i - 1;
                }

                counter--;
                Console.WriteLine("Selected To-Do item deleted.");
                return true;
            }
        }
    }
}
