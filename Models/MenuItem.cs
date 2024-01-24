using studenten_voortgang_applicatie.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public Action Action { get; set; }

 



    }
}


/*







class Menu
{
    private List<MenuItem> menuItems = new List<MenuItem>();

    public void AddMenuItem(string title, Action action)
    {
        MenuItem menuItem = new MenuItem
        {
            Title = title,
            Action = action
        };

        menuItems.Add(menuItem);
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i].Title}");
        }
        Console.WriteLine("0. Exit");
    }

    public void Run()
    {
        while (true)
        {
            DisplayMenu();

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    break;
                }

                if (choice > 0 && choice <= menuItems.Count)
                {
                    menuItems[choice - 1].Action.Invoke();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine();
        }
    }
}

class MyMethods
{
    public static void PrintMessage()
    {
        Console.WriteLine("This is a message from MyMethods class!");
    }
}

class Program
{
    static void Main()
    {
        Menu mainMenu = new Menu();

        mainMenu.AddMenuItem("Print Message from MyMethods", MyMethods.PrintMessage);

        mainMenu.Run();
    }
}



namespace ConsoleApp
{
    class Program
    {
        public static List<Option> options;
        static void Main(string[] args)
        {
            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("Thing", () => WriteTemporaryMessage("Hi")),
                new Option("Another Thing", () =>  WriteTemporaryMessage("How Are You")),
                new Option("Yet Another Thing", () =>  WriteTemporaryMessage("Today")),
                new Option("Exit", () => Environment.Exit(0)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }
        // Default action of all the options. You can create more methods
        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(options, options.First());
        }



        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
*/
