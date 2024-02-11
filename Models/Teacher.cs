using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Teacher : Employee
    {
        // courses teacher is teaching
        public HashSet<Course> Courses { get; private set; }

        // a read only collection of all students the teacher teaches
        public ReadOnlyCollection<Student> Students
        {
            get
            {
                HashSet<Student> allStudents = new HashSet<Student>();
                foreach(Course course in Courses)
                {
                    allStudents.UnionWith(course.Students);

                }
                return new ReadOnlyCollection<Student>(allStudents.ToList());
            }
        }

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
