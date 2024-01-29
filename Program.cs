using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using studenten_voortgang_applicatie.Controllers;
using studenten_voortgang_applicatie.Enums;
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

            Person loggedOnUser = new LoginController(school, new LoginView()).Authenticate();

            if(loggedOnUser != null)
            {
                SchoolController schoolController = new SchoolController(school, new StudentView());
                MenuController menuController = new MenuController(loggedOnUser);

                Menu mainMenu = CreateMenus();
                menuController.AddMenu(mainMenu);
                menuController

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
        private Menu CreateMenus()
        {
            Menu mainMenu = new Menu("Main menu");
            mainMenu.AddRole(UserRoles.Employee);

            MenuItem item = new MenuItem("Option 1");

            mainMenu.AddMenuItem(item);
        }


    }
}
