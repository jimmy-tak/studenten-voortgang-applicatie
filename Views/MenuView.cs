﻿using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace studenten_voortgang_applicatie.Views
{
    internal class MenuView : BaseView
    {
        public MenuItem DisplayMenu(Menu menu, Person user) {
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"{menu.Name}\n");
                Debug.WriteLine(menu.MenuItems.Count);

                foreach (MenuItem menuItem in menu.MenuItems)
                {
                    if (menuItem.AvailableToRoles.Intersect(user.Roles).Count() > 0) // is menuitem available to a role that the user has?
                    {
                        Console.Write($"{menu.MenuItems.IndexOf(menuItem) + 1}.\t"); 
                        Console.WriteLine(menuItem.Name);
                    }
                }
                Console.WriteLine("0.\tExit or previous menu");
                Console.Write("\nPlease enter your choice: ");

                int chosenMenuItem;
                // make sure the input corresponds to a menu option
                if(int.TryParse(Console.ReadLine(), out chosenMenuItem) && chosenMenuItem > 0 && chosenMenuItem <= menu.MenuItems.Count) 
                {                    
                    return menu.MenuItems[chosenMenuItem - 1];                    
                } 
                else if(chosenMenuItem == 0)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                }
            }
        }
    }
}
