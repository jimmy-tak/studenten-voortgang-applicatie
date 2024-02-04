using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class SchoolController
    {
        private School _school;
        private StudentView _studentView;

        public SchoolController(School school, StudentView studentView)
        {
            _school = school;
            _studentView = studentView;
        }

        // students related operations

        // display a list of all students
        public void DisplayAllStudents()
        {
            _studentView.DisplayStudents(_school.Students);
        }

        // search for a student by student number
        private Student FindStudentByStudentNumber()
        {
            return _studentView.FindStudentByStudentNumber(_school.Students);
        }

        // display a selected student
        public void DisplayStudentByStudentNumber()
        {
            _studentView.DisplayStudent(_studentView.FindStudentByStudentNumber(_school.Students));
        }  

        // remove a selected student
        public void RemoveStudent()
        {
            _school.Students.Remove(_studentView.FindStudentByStudentNumber(_school.Students));
            _studentView.DisplayPressAnyKeyToContinueMessage("Student removed");
        }

        // add a new student
        public void AddStudent()
        {
             _school.Students.Add(_studentView.AddStudent());
        }

        // edit a selected student
        public void EditStudent()
        {

        }
    }
}
