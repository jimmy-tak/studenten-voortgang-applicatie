using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Student : Person
    {
        public int StudentNumber { get; set; }
        public HashSet<Course> Courses { get; private set; } = new HashSet<Course>();
        private List<Result> _results = new List<Result>();
        public ReadOnlyCollection<Result> Results { get { return _results.AsReadOnly(); } } // we dont want anyone adding results to the collection manually

        public static int lastStudentNumber = 0;

        public Student()
        {
            StudentNumber = ++Student.lastStudentNumber;
            AddRole(UserRoles.Student);
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

        public void AddGrade(Course course, float grade)
        {
            if(!Courses.Contains(course))
            {
                throw new ArgumentException("Student is not enrolled in that course", nameof(course));
            }
            else if (grade < 0f || grade > 10f)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 10");
            }
            else
            {
                _results.Add(new Result(course, grade));
            }
        }

    }
}
