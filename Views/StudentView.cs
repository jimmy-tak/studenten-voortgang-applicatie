﻿using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class StudentView : PersonView
    {


        // display a single student
        public void DisplayStudent(Student student)
        {
            Console.WriteLine($"{student.StudentNumber}\t{student.FullName} ({student.DateOfBirth.ToString("d-M-yyyy")})");
        }

        public void DisplayStudentDetails(Student student)
        {
            Console.Clear();
            Console.WriteLine($"Student number\t: {student.StudentNumber}");
            Console.WriteLine($"Last name\t: {student.LastName}");
            Console.WriteLine($"First name\t: {student.FirstName}");
            string dateOfBearth = student.DateOfBirth != DateTime.MinValue ? student.DateOfBirth.ToString("d-M-yyyy") : "";
            Console.WriteLine($"Date of birth\t: {dateOfBearth}");
            Console.WriteLine($"Email\t\t: {student.Email}");
            Console.WriteLine($"Street\t\t: {student.Street}");
            Console.WriteLine($"Postal code\t: {student.PostalCode}");
            Console.WriteLine($"City\t\t: {student.City}");
            Console.WriteLine($"Username\t: {student.Username}");
            DisplayPressAnyKeyToContinueMessage();

        }

        // display all students
        public void DisplayStudents(HashSet<Student> students)
        {
            Console.Clear();
            foreach (Student student in students)
            {
                DisplayStudent(student);
            }

            DisplayPressAnyKeyToContinueMessage();
        }

        // find a student
        //public Student FindStudentByStudentNumber(HashSet<Student> students)
        //{
        //    int studentNumber;

            
        //    while(true) // while studentNumber is not found
        //    {
        //        Console.Clear();
        //        studentNumber = GetIntInput("Student Number");

        //        var foundStudents = students.Where(student => student.StudentNumber == studentNumber);
        //        if(foundStudents.Count() > 0) // student found
        //        {
        //            return foundStudents.First();
        //        }
        //        else
        //        {
        //            DisplayPressAnyKeyToContinueMessage("Student not found.");
        //        }
        //    }
        //}

        public Student FindStudentByStudentNumber(IEnumerable<Student> students)
        {
            int studentNumber;


            while (true) // while studentNumber is not found
            {
                Console.Clear();
                studentNumber = GetIntInput("Student Number");

                var foundStudents = students.Where(student => student.StudentNumber == studentNumber);
                if (foundStudents.Count() > 0) // student found
                {
                    return foundStudents.First();
                }
                else
                {
                    DisplayPressAnyKeyToContinueMessage("Student not found.");
                }
            }
        }

        // add a student
        public Student AddStudent()
        {
            Console.Clear();
            Console.WriteLine("Please enter the details of the student to add\n");
            Person person = GetPersonDetails(true);
            DisplayPressAnyKeyToContinueMessage();
            return new Student(person);
           
        }

        // edit a student
        public void EditStudent(Student student)
        {
            Console.Clear();
            Console.WriteLine("Please enter the details of the student to edit. Leave emtpy to not change\n");
            Person person = GetPersonDetails();
            // set student properties to person properties if they have changed
            student.FirstName = person.FirstName != "" ? person.FirstName : student.FirstName;
            student.LastName = person.LastName != "" ? person.LastName : student.LastName;
            student.DateOfBirth = person.DateOfBirth != DateTime.MinValue ? person.DateOfBirth : student.DateOfBirth;
            student.Email = person.Email != "" ? person.Email : student.Email;
            student.Street = person.Street != "" ? person.Street : student.Street;
            student.PostalCode = person.PostalCode != "" ? person.PostalCode : student.PostalCode;
            student.City = person.City != "" ? person.City : student.City;
            DisplayPressAnyKeyToContinueMessage();
        }


        // result (grade) related methods
        public void DisplayGrade(Result result)
        {
            Console.WriteLine($"{result.Course.Name}\t{result.Grade:0.00}");
        }

        public void ListAllGrades(Student student)
        {
            float total = 0;
            foreach(Result result in student.Results)
            {
                DisplayGrade(result);
                total += result.Grade;
            }
            Console.WriteLine($"Average grade: {total / student.Results.Count:0.00}");
        }

        public void ListGradesByCourse(Student student, Course course)
        {
            float total = 0;
            var results = student.Results.Where(result => result.Course == course);
            foreach(Result result in results)
            {
                DisplayGrade(result);
                total += result.Grade;
            }
            Console.WriteLine($"Average grade: {total / results.Count():0.00}");
        }

        public float GetGrade()
        {
            bool success = false;
            float grade = 0f;
            
            while(!success)
            {
                grade = GetFloadInput("Grade", true);
                if(grade < 0f || grade > 10f)
                {
                    success = true;
                }
                else
                {
                    DisplayPressAnyKeyToContinueMessage("Grade must be between 0 and 10.");
                }
            }

            return grade;
       }
    }
}
