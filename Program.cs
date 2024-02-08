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

#if DEBUG   // logging on is annoying
            Person loggedOnUser = school.Employees.First();
#else
            Person loggedOnUser = new LoginController(school, new LoginView()).Authenticate();
#endif
            if (loggedOnUser != null)
            {
                SchoolController schoolController = new SchoolController(school, new StudentView(), new CourseView());
                MenuController menuController = new MenuController(loggedOnUser, new MenuView());
                menuController.Menus = CreateMenus(schoolController);
                menuController.DisplayMenu(Menus.MainMenu); // display the main menu
            }
            // else login failed and application terminates

        }

        // build the menu's
        private List<Menu> CreateMenus(SchoolController schoolController)
        {
            return new List<Menu>()
            {
                new Menu()
                {
                    MenuId = Menus.MainMenu,
                    Name = "Main menu",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "Student administration",
                            SubMenuId = Menus.StudentAdministration,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Course administration",
                            SubMenuId = Menus.CourseAdministration,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }//,
                        //new MenuItem()
                        //{
                        //    Name = "Employee administration",
                        //    SubMenuId = 2,
                        //    AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        //}
                    }
                },
                new Menu()
                {
                    MenuId = Menus.StudentAdministration,
                    Name = "Student administration",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "List students",
                            Callback = schoolController.DisplayAllStudents,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Find student",
                            Callback = schoolController.DisplayStudentByStudentNumber,
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
                },
                new Menu()
                {
                    MenuId = Menus.CourseAdministration,
                    Name = "Course administration",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "List courses",
                            Callback = schoolController.DisplayAllCourses,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Find course",
                            Callback = schoolController.DisplayStudentByStudentNumber,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Add course",
                            Callback = schoolController.AddStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Remove course",
                            Callback = schoolController.RemoveStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Edit course",
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

            school.Students.Add(new Student() { LastName = "Jansen", FirstName = "Jan"});
            school.Courses.Add(new Course() { Code = "EN", Description = "English as a second language", Name = "English", Seats = 30 });
                 
            return school;

        }
    }
}
