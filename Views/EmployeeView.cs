using studenten_voortgang_applicatie.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class EmployeeView : PersonView
    {
        public void DisplayEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"Employee number\t: {employee.EmployeeNumber}");
            base.DisplayPersonDetails(employee);
        }

        public Employee FindEmployeeByEmployeeNumber(IEnumerable<Employee> employees)
        {
            int employeeNumber;

            while (true) // while employeeNumber is not found
            {
                Console.Clear();
                employeeNumber = GetIntInput("Employee Number", true);

                var foundEmplyees = employees.Where(employee => employee.EmployeeNumber == employeeNumber);
                if(foundEmplyees.Any())
                {
                    return foundEmplyees.First();
                }
                else
                {
                    DisplayPressAnyKeyToContinueMessage("Employee not found.");
                }
            }
        }
    }
}
