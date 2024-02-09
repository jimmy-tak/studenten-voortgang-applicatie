using studenten_voortgang_applicatie.Controllers;
using studenten_voortgang_applicatie.Enums;
using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class StudentCourseController
    {
        // models
        private School _school;
        private Student _student; // the currently logged on student
        // views
        private StudentView _studentView;
        private CourseView _courseView;
        private EnrollmentView _enrollmentView;
        private TeacherView _teacherView;

        public StudentCourseController()
        {

        }

        public StudentCourseController(School school, Student student, StudentView studentView, CourseView courseView, EnrollmentView enrollmentView)
        {
            _school = school;
            _student = student; 
            _studentView = studentView;
            _courseView = courseView;
            _enrollmentView = enrollmentView;
        }


        public void ListCourses()
        {
            _courseView.Clear();
            _courseView.DisplayCourses(_school.Courses);
            //_courseView.DisplayPressAnyKeyToContinueMessage();
        }

        public void ListEnrollments()
        {
            _enrollmentView.Clear();
            _enrollmentView.DisplayAllEnrollmentsByStudent(new HashSet<Student>() { _student });
            _enrollmentView.DisplayPressAnyKeyToContinueMessage();
        }

        public void Enroll()
        {
            _enrollmentView.Clear();
            Course course = _courseView.FindCourseByCode(_school.Courses);
            if(_student.Courses.Contains(course))
            {
                _enrollmentView.DisplayPressAnyKeyToContinueMessage($"Unable to enroll in course {course.Name}. You are already enrolled to this course.");

            }
            else if (course.HasAvailableSeats)
            {
                course.Enroll(_student);
                _enrollmentView.DisplayPressAnyKeyToContinueMessage($"You are now enrolled in course {course.Name}");
            }
            else
            {
                _enrollmentView.DisplayPressAnyKeyToContinueMessage($"Unable to enroll in course {course.Name}. Maximum number of seats has been reached");
            }
        }

        public void Unenroll()
        {
            _enrollmentView.Clear();
            Course course = _courseView.FindCourseByCode(_student.Courses);
            course.UnEnroll(_student);
            _enrollmentView.DisplayPressAnyKeyToContinueMessage($"You are now unenrolled from course {course.Name}");
        }

        public void ListResults()
        {

        }


    }
                        
}
