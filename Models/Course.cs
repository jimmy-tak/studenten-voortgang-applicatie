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

        // set containing enrolled students
        private HashSet<Student> students;

        // constructor
        public Course() { }

        // add a student to the course
        public void Enroll (Student student)
        {
            if (student == null) return;
            if (students == null) students = new HashSet<Student>();
            students.Add(student);
        }

        // add multiple students to the course
        // #not_implemented
        public void Enroll(HashSet<Student> students)
        {
            if (students == null) return;
            if (this.students == null) this.students = new HashSet<Student>();
            // ???
        }

        // remove a student from the course
        public void UnEnroll (Student student)
        {
            if (student == null) return;
            if (students == null) return;
            students.Remove(student);
        }

        // return the number of enrolled students
        public int numEnrollments()
        {
            if(students == null) return 0;
            return students.Count();
        }
    }
}
