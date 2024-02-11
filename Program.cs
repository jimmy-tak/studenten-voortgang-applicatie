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

            if (loggedOnUser != null)
            {
                // create views
                StudentView studentView = new StudentView();
                CourseView courseView = new CourseView();
                EnrollmentView enrollmentView = new EnrollmentView(studentView, courseView);
                TeacherView teacherView = new TeacherView();
                // create controllers
                SchoolController schoolController = new SchoolController(school, studentView, courseView, enrollmentView, teacherView);
                // studentcontroller is only needed when student is logged on. there's probably a better way to do this
                StudentCourseController studentCourseController = new StudentCourseController();
                if (loggedOnUser.HasRole(UserRoles.Student))
                {
                    studentCourseController = new StudentCourseController(school, (Student)loggedOnUser, studentView, courseView, enrollmentView);
                }
                MenuController menuController = new MenuController(loggedOnUser, new MenuView());
                // create menus
                menuController.Menus = CreateMenus(schoolController, studentCourseController);
                menuController.DisplayMenu(Menus.MainMenu);
            }
            // else login failed and application terminates

        }

        // build the menu's
        private List<Menu> CreateMenus(SchoolController schoolController, StudentCourseController studentCourseController)
        {
            return new List<Menu>()
            {
                new Menu()
                {
                    MenuId = Menus.MainMenu,
                    Name = "Main menu",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Student, UserRoles.Teacher, UserRoles.Employee, UserRoles.Guardian, UserRoles.Administrator }, // main menu is available to everyone
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
                            Name = "Teacher administration",
                            SubMenuId = Menus.TeacherAdministration,
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
                        },
                        new MenuItem()
                        {
                            Name = "Student menu",
                            SubMenuId = Menus.StudentMenu,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
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
                    MenuId = Menus.TeacherAdministration,
                    Name = "Teacher administration",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Employee },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "List teachers",
                            Callback = schoolController.DisplayAllTeachers,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Find teacher",
                            Callback = schoolController.DisplayTeacherByEmployeeNumber,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Add teacher",
                            Callback = schoolController.AddTeacher,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Remove teacher",
                            Callback = schoolController.RemoveTeacher,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Edit teacher",
                            Callback = schoolController.EditTeacher,
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
                        },
                        new MenuItem()
                        {
                            Name = "Assign teacher",
                            Callback = schoolController.AssignTeacherToCourse,
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
                            Name = "List all enrollments by student",
                            Callback = schoolController.DisplayAllEnrollmentsByStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "List all enrollments by course",
                            Callback = schoolController.DisplayAllEnrollmentsByCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Find enrollments by student",
                            Callback = schoolController.DisplayEnrollmentsByStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Find enrollments by course ",
                            Callback = schoolController.DisplayEnrollmentsByCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Enroll student to course",
                            Callback = schoolController.EnrollStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        },
                        new MenuItem()
                        {
                            Name = "Unenroll student from course",
                            Callback = schoolController.UnenrollStudent,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Employee }
                        }
                    }
                },
                new Menu()
                {
                    MenuId = Menus.StudentMenu,
                    Name = "Student menu",
                    AvailableToUserRoles = new List<UserRoles> () { UserRoles.Student },
                    MenuItems = new List<MenuItem> ()
                    {
                        new MenuItem()
                        {
                            Name = "List all courses",
                            Callback = studentCourseController.ListCourses,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
                        },
                        new MenuItem()
                        {
                            Name = "List my enrollments",
                            Callback = studentCourseController.ListEnrollments,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
                        },
                        new MenuItem()
                        {
                            Name = "Ernoll in a course",
                            Callback = studentCourseController.Enroll,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
                        },                        
                        new MenuItem()
                        {
                            Name = "Unenroll from a course",
                            Callback = studentCourseController.Unenroll,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
                        },
                        new MenuItem()
                        {
                            Name = "List my grades",
                            Callback = studentCourseController.ListAllGrades,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
                        },
                        new MenuItem()
                        {
                            Name = "List my grades for a particular course",
                            Callback = studentCourseController.ListGradesByCourse,
                            AvailableToRoles = new List<UserRoles> () { UserRoles.Student }
                        }
                    }
                }
            };
        }

        private School CreateSampleData()
        {
            School school = new School("Curio", "25LX");

            Employee employee1 = new Employee() { FirstName = "first", LastName = "last" };
            employee1.Username = "jimmy";
            employee1.Password = "1234"; // no try catch in sample data
            school.AddEmployee(employee1);

            Student student1 = new Student() { LastName = "Student", FirstName = "Jan" };
            student1.Username = "stud";
            student1.Password = "1234";
            school.Students.Add(student1);


            Student student2 = new Student() { LastName = "Student2", FirstName = "Jan" }; 
            school.Students.Add(student2);

            Course course1 = new Course() { Code = "NL", Description = "Dutch as a second language", Name = "Dutch", Seats = 10 };
            school.Courses.Add(course1);
            course1.Enroll(student1);
            

            Course course2 = new Course() { Code = "M", Description = "Advanced math", Name = "Math", Seats = 2 };
            school.Courses.Add(course2);
            course2.Enroll(student2);

            course2.Enroll(student1);

            student1.AddGrade(course1, 8.9f);
            student1.AddGrade(course1, 4.9f);
            student1.AddGrade(course2, 5.3f);
            student1.AddGrade(course2, 8.2f);
            student1.AddGrade(course2, 7.3f);



            Teacher teacher1 = new Teacher() { LastName = "Docent", FirstName = "Piet" };
            school.Teachers.Add(teacher1);
            course1.Teacher = teacher1;
                 
            return school;
        }
    }
}
