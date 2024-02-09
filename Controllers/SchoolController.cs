using studenten_voortgang_applicatie.Views;
using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Controllers
{
    // SchoolController contains most business logic
    internal class SchoolController
    {
        // models
        private School _school;
        // views
        private StudentView _studentView;
        private CourseView _courseView;
        private EnrollmentView _enrollmentView;


        public SchoolController(School school, StudentView studentView, CourseView courseView, EnrollmentView enrollmentView)
        {
            _school = school;
            _studentView = studentView;
            _courseView = courseView;
            _enrollmentView = enrollmentView;
        }

        // Student related operations //

        // display a list of all students
        public void DisplayAllStudents()
        {
            _studentView.DisplayStudents(_school.Students);
        }


        // display a selected student
        public void DisplayStudentByStudentNumber()
        {
            _studentView.DisplayStudentDetails(_studentView.FindStudentByStudentNumber(_school.Students));
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
            _studentView.EditStudent(_studentView.FindStudentByStudentNumber(_school.Students));
        }


        // Course related methods //

        // display a list of all courses
        public void DisplayAllCourses()
        {
            _courseView.DisplayCourses(_school.Courses);
        }

        // search for a course by code
        private Course FindCourseByCode()
        {
            return _courseView.FindCourseByCode(_school.Courses);
        }

        // display a selected course
        public void DisplayCourseByCode()
        {
            _courseView.DisplayCourseDetails(_courseView.FindCourseByCode(_school.Courses));
        }

        // remove a selected course
        public void RemoveCourse()
        {
            _school.Courses.Remove(_courseView.FindCourseByCode(_school.Courses));
            _courseView.DisplayPressAnyKeyToContinueMessage("Course removed");
        }

        // add a new course
        public void AddCourse()
        {
            _school.Courses.Add(_courseView.AddCourse());
        }

        // edit a selected course
        public void EditCourse()
        {
            _courseView.EditCourse(_courseView.FindCourseByCode(_school.Courses));
        }

        // Enrollment related methods //

        // display all enrollments
        public void DisplayEnrollmentsByStudent()
        {
            _enrollmentView.Clear();
            _enrollmentView.DisplayEnrollmentsByStudent(_studentView.FindStudentByStudentNumber(_school.Students));
            _enrollmentView.DisplayPressAnyKeyToContinueMessage();
        }

        public void DisplayEnrollmentsByCourse()
        {
            _enrollmentView.Clear();
            _enrollmentView.DisplayEnrollmentsByCourse(_courseView.FindCourseByCode(_school.Courses));
            _enrollmentView.DisplayPressAnyKeyToContinueMessage();
        }

        public void DisplayAllEnrollmentsByCourse()
        {
            _enrollmentView.Clear();
            _enrollmentView.DisplayAllEnrollmentsByCourse(_school.Courses);
            _enrollmentView.DisplayPressAnyKeyToContinueMessage();
        }

        public void DisplayAllEnrollmentsByStudent()
        {
            _enrollmentView.Clear();
            _enrollmentView.DisplayAllEnrollmentsByStudent(_school.Students);
            _enrollmentView.DisplayPressAnyKeyToContinueMessage();
        }
    }
}
