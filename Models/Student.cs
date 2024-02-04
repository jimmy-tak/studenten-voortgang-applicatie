using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Student : Person
    {
        public int StudentNumber { get; set; }

        private static int lastStudentNumber = 0;

        public Student(string firstName, string lastName) : base(firstName, lastName) {
            StudentNumber = ++Student.lastStudentNumber;
            addRole(UserRoles.Student);
        }

    }
}
