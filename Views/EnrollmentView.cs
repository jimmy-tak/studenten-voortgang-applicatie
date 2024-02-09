using studenten_voortgang_applicatie.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class EnrollmentView : BaseView
    {

        private StudentView _studentView;
        private CourseView _courseView;

        public EnrollmentView(StudentView studentView, CourseView courseView)
        {
            _studentView = studentView;
            _courseView = courseView;
        }


        // display a single enrollment
        public void DisplayAllEnrollmentsByCourse(Course course)
        {
            Console.Clear();
            _courseView.DisplayCourse(course);

            foreach(Student student in course.Students)
            {
                _studentView.DisplayStudent(student);
            }

            DisplayPressAnyKeyToContinueMessage();

        }

        // display all enrollments
        public void DisplayAllEnrollmentsByStudent(Student student)
        {
            Console.Clear();
            _studentView.DisplayStudent(student);


            foreach (Course course in student.Courses)
            {
                _courseView.DisplayCourse(course);
            }

            DisplayPressAnyKeyToContinueMessage();
        }
    }
}
