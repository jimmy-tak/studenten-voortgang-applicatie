using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class School
    {
        public string Name { get; set; }
        public string BrinNummer { get; set; }


        public HashSet<Employee> Employees { get; private set; }
        // teachers are employees, but its easier to keep them seperated
        public HashSet<Teacher> Teachers { get; private set; }
        public HashSet<Student> Students { get; private set; }        
        public HashSet<Parent> Parents { get; private set; }
        public HashSet<Course> Courses { get; private set; }
        public HashSet<Person> Users
        {
            get
            {
                HashSet<Person> allUsers = new HashSet<Person>();
                allUsers.UnionWith(Employees);
                allUsers.UnionWith(Teachers);
                allUsers.UnionWith(Students);
                allUsers.UnionWith(Parents);
                return allUsers;
            }
        }


        public School(string name, string brinNummer) 
        {
            Name = name;
            BrinNummer = brinNummer;
            Employees = new HashSet<Employee>();
            Teachers = new HashSet<Teacher>();
            Students = new HashSet<Student>();
            Parents = new HashSet<Parent>();
            Courses = new HashSet<Course>();
            //Enrollments = new HashSet<Enrollment>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

    }
}
