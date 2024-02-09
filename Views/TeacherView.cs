using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class TeacherView : EmployeeView

    {


        // display a single teacher
        public void DisplayTeacher(Teacher teacher)
        {
            Console.WriteLine($"{teacher.EmployeeNumber}\t{teacher.FullName} ({teacher.DateOfBirth.ToString("d-M-yyyy")})");
        }

        public void DisplayTeacherDetails(Teacher teacher)
        {
            base.DisplayEmployeeDetails(teacher);
        }

        // display all teachers
        public void DisplayAllTeachers(IEnumerable<Teacher> teachers)
        {
            foreach (Teacher teacher in teachers)
            {
                DisplayTeacher(teacher);
            }
        }

        // find a teacher
        public Teacher FindTeacherByTeacherEmployeeNumber(IEnumerable<Teacher> teachers)
        {
            return (Teacher)FindEmployeeByEmployeeNumber(teachers.Cast<Employee>()); // cast all items in collection to base class
        }

        // add a teacher
        public Teacher AddTeacher()
        {
            Console.WriteLine("Please enter the details of the teacher to add\n");
            Person person = GetPersonDetails(true);
            DisplayPressAnyKeyToContinueMessage();
            return new Teacher(person);

        }

        // edit a teacher
        public void EditTeacher(Teacher teacher)
        {
            Console.Clear();
            Console.WriteLine("Please enter the details of the teacher to edit. Leave emtpy to not change\n");
            Person person = GetPersonDetails();
            // set teacher properties to person properties if they have changed
            teacher.FirstName = person.FirstName != "" ? person.FirstName : teacher.FirstName;
            teacher.LastName = person.LastName != "" ? person.LastName : teacher.LastName;
            teacher.DateOfBirth = person.DateOfBirth != DateTime.MinValue ? person.DateOfBirth : teacher.DateOfBirth;
            teacher.Email = person.Email != "" ? person.Email : teacher.Email;
            teacher.Street = person.Street != "" ? person.Street : teacher.Street;
            teacher.PostalCode = person.PostalCode != "" ? person.PostalCode : teacher.PostalCode;
            teacher.City = person.City != "" ? person.City : teacher.City;
            DisplayPressAnyKeyToContinueMessage();

        }
    }
}
