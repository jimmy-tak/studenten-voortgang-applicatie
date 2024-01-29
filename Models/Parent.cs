using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Parent : Person
    {
        private HashSet<Student> children;

        public Parent(string firstName, string lastName) : base(firstName, lastName)
        {
            addRole(UserRoles.Guardian);
        }
    }
}
