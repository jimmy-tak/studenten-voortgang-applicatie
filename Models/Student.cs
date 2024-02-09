using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Student : Person
    {
        public int StudentNumber { get; set; }

        public HashSet<Course> Courses { get; private set; }

        public static int lastStudentNumber = 0;

        public Student()
        {
            StudentNumber = ++Student.lastStudentNumber;
            AddRole(UserRoles.Student);
            Courses = new HashSet<Course>();
        }

        // create a student based on a person
        public Student(Person person) : this()
        {
            LastName = person.LastName;
            FirstName = person.FirstName;
            DateOfBirth = person.DateOfBirth;
            Email = person.Email;
            Street = person.Street;
            PostalCode = person.PostalCode; 
            City = person.City;
        }



    }
}
