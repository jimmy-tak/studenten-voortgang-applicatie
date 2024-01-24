using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Teacher : Employee
    {
        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
            addRole(UserRoles.Teacher);
        }
    }
}
