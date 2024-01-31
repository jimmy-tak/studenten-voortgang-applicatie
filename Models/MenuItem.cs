using studenten_voortgang_applicatie.Controllers;
using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal record MenuItem
    {
        public string Name { get; set; }        
        public Action? Callback { get; set; }
        public int? SubMenuId { get; set; }
        public List<UserRoles> AvailableToRoles { get; set; }
    }
}

