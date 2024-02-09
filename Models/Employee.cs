using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Employee : Person
    {
        public int EmployeeNumber { get; private set; }
        public static int lastEmployeeNumber = 0;

        public Employee()
        {
            EmployeeNumber = ++Employee.lastEmployeeNumber;
            AddRole(UserRoles.Employee);
        }

        public Employee(Person person) : base()
        {
            EmployeeNumber = ++Employee.lastEmployeeNumber;
            AddRole(UserRoles.Employee);
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
