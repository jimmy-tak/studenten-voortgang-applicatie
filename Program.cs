using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using studenten_voortgang_applicatie.Controllers;
using studenten_voortgang_applicatie.Enums;

using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Authentication;
using System.Xml.Linq;

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
                MenuController menuController = new MenuController(loggedOnUser, new MenuView());
                menuController.Menus = CreateMenus(schoolController);
                menuController.DisplayMenu(0); // main menu
            }
            // else login failed and application terminates
        }

        private List<Menu> CreateMenus(SchoolController schoolController)
        {
            return new List<Menu>()
            {
                new Menu()
                {
                    Id = 0,
                    Name = "Main menu",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "Student administration",
                            SubMenuId = 1,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Course administration",
                            Callback = schoolController.AddStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Employee administration",
                            SubMenuId = 2,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }
                    }
                },
                new Menu()
                {
                    Id = 1,
                    Name = "Student administration",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "List students",
                            Callback = schoolController.ListStudents,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Add student",
                            Callback = schoolController.AddStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Remove student",
                            Callback = schoolController.RemoveStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Edit student",
                            Callback = schoolController.EditStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }
                    }
                }
            };
        }

        private School CreateSampleData()
        {
            School school = new School("Curio", "25LX");
            Employee employee = new Employee("Jimmy", "Tak");
            employee.Username = "jimmy";
            employee.Password = "1234"; // no try catch in sample data
            employee.EmployeeNumber = "1";
            school.AddEmployee(employee);

            school.Students.Add(new Student("Jan", "Jansen"));

            return school;

        }
    }
}
