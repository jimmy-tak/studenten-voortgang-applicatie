using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class StudentView : BaseView
    {
        public void ListStudents(HashSet<Student> students)
        {
            Console.Clear();
            foreach (Student student in students)
            {                
                DisplayStudent(student);
            }
            DisplayPressAnyKeyToContinueMessage();
        }

        public void DisplayStudent(Student student)
        {
            Console.WriteLine($"{student.FullName} ({student.StudentNumber})");
        }

        public Student FindStudent()
        {

        }
        public void RemoveStudent()
        {

        }

        public Student AddStudent()
        {
            string lastName, firstName;
            DateTime dateOfBirth;

            Console.Clear();
            Console.Write("Last name: ");
            lastName = Console.ReadLine();
            Console.Write("First name: ");
            firstName = Console.ReadLine();
            Console.Write("Date of birth: ");
            Console.ReadLine();

            return new Student(firstName, lastName);
        }

        public void EditStudent()
        {

        }
    }
}
