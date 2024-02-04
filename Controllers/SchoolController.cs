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

        // students
        public void ListStudents()
        {
            _studentView.ListStudents(_school.Students);
        }

        public void FindStudent()
        {
            Student student = _studentView.FindStudent();
        }

        public void DisplayStudent()
        {
            _studentView.DisplayStudent(_studentView.FindStudent());
        }

        public void RemoveStudent()
        {

        }

        public void AddStudent()
        {
             _school.Students.Add(_studentView.AddStudent());
        }

        public void EditStudent()
        {

        }
    }
}
