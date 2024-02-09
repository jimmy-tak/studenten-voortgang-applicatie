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

        // display enrollments for a single course
        public void DisplayEnrollmentsByCourse(Course course)
        {
            _courseView.DisplayCourse(course);
            Console.WriteLine($"Seats: ({course.CountEnrollments()} of {course.Seats})\n");

            foreach (Student student in course.Students)
            {
                _studentView.DisplayStudent(student);
            }
        }

        // display enrollments for a single student
        public void DisplayEnrollmentsByStudent(Student student)
        {
            _studentView.DisplayStudent(student);

            foreach (Course course in student.Courses)
            {
                _courseView.DisplayCourse(course);
            }
        }

        // display enrollments for all student
        public void DisplayAllEnrollmentsByStudent(HashSet<Student> students)
        {
            foreach(Student student in students)
            {
                DisplayEnrollmentsByStudent(student);
                DisplayEmptyLine(2);
            }
        }

        // display enrollments for all courses
        public void DisplayAllEnrollmentsByCourse(HashSet<Course> courses)
        {
            foreach (Course course in courses)
            {
                DisplayEnrollmentsByCourse(course);
                DisplayEmptyLine(2);
            }
        }

    }
}
