using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal abstract class BaseView
    {
        // clears the console
        public void Clear()
        {
            Console.Clear();
        }

        // writes a number of emtpy lines
        public void DisplayEmptyLine(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine();
            }
        }

        // display a press any key to continue message
        public void DisplayPressAnyKeyToContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // display a press any key to continue message with an additional message
        public void DisplayPressAnyKeyToContinueMessage(string message)
        {
            Console.Write(message);
            DisplayPressAnyKeyToContinueMessage();
        }

        // get a string input
        protected string GetStringInput(string text, bool required = false) // maybe use generics
        {
            string input;
            string requiredNotification = required ? " (required)" : string.Empty;
            do
            {
                Console.Write($"{text}{requiredNotification}: ");
                input = Console.ReadLine();
            }
            while (required && input == "");

            return input;
        }

        protected int GetIntInput(string text, bool required = false)
        {
            string input;
            int number;
            bool success;
            do
            {
                Console.Write($"{text}: ");
                input = Console.ReadLine();
                if (input == "" && required == false) return int.MinValue; // so we can skip entering int
                success = int.TryParse(input, out number);
            }
            while(!success);

            return number;
        }

        // get a datetime input
        protected DateTime GetDateTimeInput(string text, bool required = false)
        {
            string input;
            DateTime dateTime;
            bool success;
            do
            {
                Console.Write($"{text} (d-M-yyyy): ");
                input = Console.ReadLine();
                if (input == "" && required == false) return DateTime.MinValue; // so we can skip entering datetime
                success = DateTime.TryParseExact(input, "d-M-yyyy", new CultureInfo("nl-NL"), DateTimeStyles.None, out dateTime);
            }
            while (!success);

            return dateTime;
        }
    }
}
