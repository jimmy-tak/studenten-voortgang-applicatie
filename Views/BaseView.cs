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
        protected string GetStringInput(string text) // maybe use generics
        {
            Console.Write($"{text}: ");
            return Console.ReadLine();
        }

        protected int GetIntInput(string text)
        {
            int number;
            bool success;
            do
            {
                Console.Write($"{text}: ");
                success = int.TryParse(Console.ReadLine(), out number);
            }
            while(!success);

            return number;
        }

        // get a datetime input
        protected DateTime GetDateTimeInput(string text)
        {
            DateTime dateTime;
            bool success;
            do
            {
                Console.Write($"{text} (d-M-yyyy): ");
                string inputDateTime = Console.ReadLine();
                if (inputDateTime == "") return DateTime.MinValue; // so we can skip entering datetime
                success = DateTime.TryParseExact(inputDateTime, "d-M-yyyy", new CultureInfo("nl-NL"), DateTimeStyles.None, out dateTime);
            }
            while (!success);

            return dateTime;
        }
    }
}
