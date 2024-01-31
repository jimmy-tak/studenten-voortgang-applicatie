using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal record Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<UserRoles> AvailableToUserRoles { get; set; }
    }
}


