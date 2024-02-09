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
                StudentView studentView = new StudentView();
                CourseView courseView = new CourseView();
                EnrollmentView enrollmentView = new EnrollmentView(studentView, courseView);
                SchoolController schoolController = new SchoolController(school, studentView, courseView, enrollmentView);
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
                        },
                        new MenuItem()
                        {
                            Name = "Enrollment administration",
                            SubMenuId = Menus.EnrollmentAdministration,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }
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
                            Callback = schoolController.DisplayCourseByCode,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Add course",
                            Callback = schoolController.AddCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Remove course",
                            Callback = schoolController.RemoveCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Edit course",
                            Callback = schoolController.EditCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }
                    }
                },
                new Menu()
                {
                    MenuId = Menus.EnrollmentAdministration,
                    Name = "Enrollment administration",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "List enrollments by student",
                            Callback = schoolController.DisplayAllEnrollmentsByStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Find enrollment",
                            Callback = schoolController.DisplayCourseByCode,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Add enrollment",
                            Callback = schoolController.AddCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Remove enrollment",
                            Callback = schoolController.RemoveCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }//,
                        //new MenuItem()
                        //{
                        //    Name = "Edit course",
                        //    Callback = schoolController.EditCourse,
                        //    AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        //}
                    }
                }
            };
        }

        private School CreateSampleData()
        {
            School school = new School("Curio", "25LX");
            Employee employee = new Employee() { FirstName = "first", LastName = "last" };
            employee.Username = "jimmy";
            employee.Password = "1234"; // no try catch in sample data
            employee.EmployeeNumber = "1";
            school.AddEmployee(employee);

            Student student1 = new Student() { LastName = "Jansen", FirstName = "Jan" };
            school.Students.Add(student1);
            Course course1 = new Course() { Code = "EN", Description = "English as a second language", Name = "English", Seats = 30 };
            school.Courses.Add(course1);
            course1.Enroll(student1 );

                 
            return school;

        }
    }
}
