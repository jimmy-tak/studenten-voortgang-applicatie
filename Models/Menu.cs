using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Menu
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; }
        public List<UserRoles> AvailableToUserRoles { get; }
        
        public Menu(string name)
        {
            Name = name;
            MenuItems = new List<MenuItem>();
            AvailableToUserRoles = new List<UserRoles>();
        }

        public void AddMenuItem(MenuItem item)
        {
            MenuItems.Add(item);
        }

        public void AddRole(UserRoles role)
        {
            AvailableToUserRoles.Add(role);
        }
    }
}


