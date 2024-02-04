using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Student FindStudentByStudentNumber(HashSet<Student> students)
        {
            int studentNumber;

            while(true) // while studentNumber is not found
            {
                studentNumber = GetIntInput("Student Number");
                //if (studentNumber <= 0 || studentNumber > Student.lastStudentNumber) continue; // input student number does not exist

                var foundStudents = students.Where(student => student.StudentNumber == studentNumber);
                if(foundStudents != null)
                {
#if DEBUG
                    Debug.WriteLine(foundStudents.First());
#endif
                    return foundStudents.First();
                }
            }
        }

        // remove a student
        public Student RemoveStudent()
        {
            return null;
        }

        // add a student
        public Student AddStudent()
        {
            string lastName, firstName, email, street, postalCode, city;
            DateTime dateOfBirth;

            Console.Clear();
            Console.WriteLine("Please enter details of the student to add\n");

            lastName = GetStringInput("Last name");
            firstName = GetStringInput("First name");
            dateOfBirth = GetDateTimeInput("Date of birth");
            email = GetStringInput("Email");
            street = GetStringInput("Street");
            postalCode = GetStringInput("Postal code");
            city = GetStringInput("city");

            DisplayPressAnyKeyToContinueMessage();

            return new Student(firstName, lastName)
            {
                DateOfBirth = dateOfBirth,
                Email = email,
                Street = street,
                PostalCode = postalCode,
                City = city

            };
           
        }

        // edit a student
        public void EditStudent()
        {

        }
    }
}
