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
        // courses teacher is teaching
        public HashSet<Course> Courses { get; private set; }

        public Teacher() : base()
        {
            AddRole(UserRoles.Teacher);
        }

        public Teacher(Person person) : base(person)
        {
            AddRole(UserRoles.Teacher);

        }
    }
}
