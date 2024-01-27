using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using studenten_voortgang_applicatie.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Authentication;

namespace studenten_voortgang_applicatie
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public Program()
        {
            Console.Title = "Studenten voortgang applicatie";
        }

        public void Run()
        {
            School school = CreateSampleData();

            Person loggedOnUser = new LoginController(new LoginView(), school).Authenticate();

            if(loggedOnUser != null)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {loggedOnUser.FullName}");
                Console.WriteLine($"You have role Student {loggedOnUser.HasRole(Enums.UserRoles.Student)}");
                Console.WriteLine($"You have role Employee {loggedOnUser.HasRole(Enums.UserRoles.Employee)}");
                Console.ReadKey();
            }
            // else login failed
        }

        private School CreateSampleData()
        {
            School school = new School("Curio", "25LX");
            Employee employee = new Employee("Jimmy", "Tak");
            employee.Username = "jimmy";
            employee.Password = "1234"; // no try catch in sample data
            employee.EmployeeNumber = "1";
            school.AddEmployee(employee);

            return school;

        }
        private void CreateMenus()
        {

        }


    }
}
