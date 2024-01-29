using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using studenten_voortgang_applicatie.Models;

namespace studenten_voortgang_applicatie.Views
{
    internal class MenuView
    {
        public MenuItem DisplayMenu(Menu menu)
        {
            while(true)
            {
                int chosenMenuItem;

                Console.Clear();

                foreach (MenuItem menuItem in menu.MenuItems)
                {
                    Console.Write($"{menu.MenuItems.IndexOf(menuItem)}.\t"); // slow but fun
                    Console.WriteLine(menuItem.Name);
                }
                Console.WriteLine("0.\tExit or previous menu");
                Console.Write("\nPlease enter your choose: ");

                if (int.TryParse(Console.ReadLine(), out chosenMenuItem))
                {
                    if (chosenMenuItem == 0)
                    {
                        return null;
                    }
                    else if (chosenMenuItem < menu.MenuItems.Count)
                    {
                        return menu.MenuItems[chosenMenuItem - 1];
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid menu option");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                    Console.ReadKey();
                }

            }




            
        }


    }
}
