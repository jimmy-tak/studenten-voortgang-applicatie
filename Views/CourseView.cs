using studenten_voortgang_applicatie.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace studenten_voortgang_applicatie.Views
{
    internal class CourseView : BaseView
    {

        // display a single course
        public void DisplayCourse(Course Course)
        {
            Console.WriteLine($"{Course.Code}\t{Course.Name} ({Course.Description})");
        }

        public void DisplayCourseDetails(Course Course)
        {
            Console.Clear();

            Console.WriteLine($"Code\t\t: {Course.Code}");
            Console.WriteLine($"Name\t\t: {Course.Name}");
            Console.WriteLine($"Description\t: {Course.Description}");
            int seats = Course.Seats > 0 ? Course.Seats : 0;
            Console.WriteLine($"Seats\t\t: {seats}");

            DisplayPressAnyKeyToContinueMessage();

        }

        //// display a single Course and wait
        //public void DisplayCourseAndWait(Course Course)
        //{
        //    Console.Clear();
        //    DisplayCourse(Course);
        //    DisplayPressAnyKeyToContinueMessage();
        //}

        // display all Courses
        public void DisplayCourses(HashSet<Course> Courses)
        {
            Console.Clear();
            foreach (Course Course in Courses)
            {
                DisplayCourse(Course);
            }

            DisplayPressAnyKeyToContinueMessage();
        }

        // find a Course
        public Course FindCourseByCode(HashSet<Course> Courses)
        {
            string code;


            while (true) // while CourseNumber is not found
            {
                Console.Clear();
                code = GetStringInput("Code");

                var foundCourses = Courses.Where(course => course.Code == code);
                if (foundCourses.Count() > 0) // Course found
                {
                    return foundCourses.First();
                }
                else
                {
                    DisplayPressAnyKeyToContinueMessage("Course not found.");
                }
            }
        }

        private Course GetCourseDetails(bool required = false) // dont ask for required fields when editing
        {
            string name, description, code;
            int seats;

            name = GetStringInput("Name");
            description = GetStringInput("Description");
            code = GetStringInput("Code (required)", required);
            seats = GetIntInput("Seats");
       
            return new Course()
            {
                Name = name,
                Description = description,
                Code = code,
                Seats = seats
            };
        }


        // add a Course
        public Course AddCourse()
        {
            Console.Clear();
            Console.WriteLine("Please enter the details of the Course to add\n");

            Course course = GetCourseDetails(true);
            DisplayPressAnyKeyToContinueMessage();

            return course;
        }

        // edit a Course
        public void EditCourse(Course course)
        {
            Console.Clear();
            Console.WriteLine("Please enter the details of the Course to edit. Leave emtpy to not change\n");
            Course newCourse = GetCourseDetails();
            // set Course properties to newCourse properties if they have changed
            course.Code = course.Code != "" ? newCourse.Code : course.Code;
            course.Description = course.Description != "" ? newCourse.Description : course.Description;
            course.Name = course.Name != "" ? newCourse.Name : course.Name;
            course.Seats = course.Seats != int.MinValue ? newCourse.Seats : course.Seats;

            DisplayPressAnyKeyToContinueMessage();

        }

    }
}
