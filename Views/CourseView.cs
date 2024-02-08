using studenten_voortgang_applicatie.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class CourseView : BaseView
    {

        // display a single course
        private void DisplayCourse(Course Course)
        {
            Console.WriteLine($"{Course.Code}\t{Course.Name} ({Course.Description})");
        }

        //public void DisplayCourseDetails(Course Course)
        //{
        //    Console.Clear();
        //    Console.WriteLine($"Course number\t: {Course.CourseNumber}");
        //    Console.WriteLine($"Last name\t: {Course.LastName}");
        //    Console.WriteLine($"First name\t: {Course.FirstName}");
        //    Console.WriteLine($"Date of birth\t: {Course.DateOfBirth.ToString("d-M-yyyy")}");
        //    Console.WriteLine($"Email\t\t: {Course.Email}");
        //    Console.WriteLine($"Street\t\t: {Course.Street}");
        //    Console.WriteLine($"Postal code\t: {Course.PostalCode}");
        //    Console.WriteLine($"City\t\t: {Course.City}");
        //    Console.WriteLine($"Username\t: {Course.Username}");
        //    DisplayPressAnyKeyToContinueMessage();

        //}

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

        //// find a Course
        //public Course FindCourseByCourseNumber(HashSet<Course> Courses)
        //{
        //    int CourseNumber;


        //    while (true) // while CourseNumber is not found
        //    {
        //        Console.Clear();
        //        CourseNumber = GetIntInput("Course Number");

        //        var foundCourses = Courses.Where(Course => Course.CourseNumber == CourseNumber);
        //        if (foundCourses.Count() > 0) // Course found
        //        {
        //            return foundCourses.First();
        //        }
        //        else
        //        {
        //            DisplayPressAnyKeyToContinueMessage("Course not found.");
        //        }
        //    }
        //}

        // add a Course
        public Course AddCourse()
        {
            Console.Clear();
            Console.WriteLine("Please enter the details of the Course to add\n");
            
            DisplayPressAnyKeyToContinueMessage();
            return new Course();

        }

        //// edit a Course
        //public void EditCourse(Course Course)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Please enter the details of the Course to edit. Leave emtpy to not change\n");
        //    Person person = CreatePerson();
        //    // set Course properties to person properties if they have changed
        //    Course.FirstName = person.FirstName != "" ? person.FirstName : Course.FirstName;
        //    Course.LastName = person.LastName != "" ? person.LastName : Course.LastName;
        //    Course.DateOfBirth = person.DateOfBirth != DateTime.MinValue ? person.DateOfBirth : Course.DateOfBirth;
        //    Course.Email = person.Email != "" ? person.Email : Course.Email;
        //    Course.Street = person.Street != "" ? person.Street : Course.Street;
        //    Course.PostalCode = person.PostalCode != "" ? person.PostalCode : Course.PostalCode;
        //    Course.City = person.City != "" ? person.City : Course.City;
        //    DisplayPressAnyKeyToContinueMessage();

        //}

    }
}
