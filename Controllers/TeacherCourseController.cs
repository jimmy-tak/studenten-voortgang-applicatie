using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class TeacherCourseController
    {
        // models
        private School _school;
        private Teacher _teacher;
        // views
        private StudentView _studentView;
        private CourseView _courseView;
        private EnrollmentView _enrollmentView;
        private TeacherView _teacherView;

        public TeacherCourseController()
        {

        }

        public TeacherCourseController(School school, Teacher teacher, StudentView studentView, CourseView courseView, EnrollmentView enrollmentView)
        {
            _school = school;
            _teacher = teacher;
            _studentView = studentView;
            _courseView = courseView;
            _enrollmentView = enrollmentView;
        } 

        public void RegisterAttendanceByCourse()
        {
            _courseView.Clear();
            Course course = _courseView.FindCourseByCode(_teacher.Courses);
            IEnumerable<Student> students = _courseView.GetAttendance();
            _courseView.DisplayPressAnyKeyToContinueMessage();


        }


        public void AddGradeByStudent()
        {
            _courseView.Clear();
            Student student = _studentView.FindStudentByStudentNumber(_teacher.Students);
            Course course = _courseView.FindCourseByCode(_teacher.Courses);
            float grade = _studentView.GetGrade();
            try // just as an example
            {
                student.AddGrade(course, grade);
            } catch(Exception ex)
            {
                _courseView.DisplayPressAnyKeyToContinueMessage($"Unable to add grade. Reason: {ex.Message}");
            }
            _courseView.DisplayPressAnyKeyToContinueMessage();
        }

        public void AddGradeByCourse()
        {

        }
    }
}
