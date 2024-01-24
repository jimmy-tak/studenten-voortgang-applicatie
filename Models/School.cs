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

        
        HashSet<Student> Students { get; set; }
        HashSet<Employee> Employees { get; set; }
        HashSet<Course> Courses { get; set; }

        public School(string name, string brinNummer) 
        {
            Name = name;
            BrinNummer = brinNummer;
            Employees = new HashSet<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

    }
}
