using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Course
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code {  get; set; }

        public int Seats { get; set; }

        // set containing enrolled students
        public HashSet<Student> Students { get; private set; }

        // constructor
        public Course() {
            Students = new HashSet<Student>();
        }

        // add a student to the course
        public void Enroll (Student student)
        {
            if (student == null) return;
            if(Students.Count <= Seats)
            {
                Students.Add(student);
                student.Courses.Add(this); // relation is two-way
            }
            else
            {
                throw new ArgumentException("Course if fully booked");
            }
        }

        //// add multiple students to the course
        //// #not_implemented
        //public void Enroll(HashSet<Student> students)
        //{
        //    if (students == null) return;
        //    if (this.Students == null) this.Students = new HashSet<Student>();
        //    // ???
        //}

        // remove a student from the course
        public void UnEnroll (Student student)
        {
            if (student == null) return;
            if (Students == null) return;
            student.Courses.Remove(this);
            Students.Remove(student);
        }

        // return the number of enrolled students
        public int CountEnrollments()
        {
            if(Students == null) return 0;
            return Students.Count;
        }
    }
}
