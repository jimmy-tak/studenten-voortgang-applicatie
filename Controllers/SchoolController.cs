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

        public void AddStudent()
        {
            _studentView.AddStudent();
        }
    }
}
