using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Course
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code {  get; set; }

        // number of students that can enroll to the course
        public int Seats { get; set; } = 0;
        [JsonIgnore]
        public bool HasAvailableSeats { get => Seats > Students.Count; }

        // set containing enrolled students
        [JsonIgnore]
        public HashSet<Student> Students { get; private set; } = new HashSet<Student>();
        public Teacher? Teacher { get; set; }

        // constructor
        public Course() {
        }

        // add a student to the course
        public void Enroll (Student student)
        {
            if (student == null) return;
            if(HasAvailableSeats)
            {
                Students.Add(student);
                student.Courses.Add(this);
            }
            else
            {
                throw new ArgumentException("Course if fully booked"); // just as an example of exceptions
            }
        }

        // remove a student from the course
        public void UnEnroll (Student student)
        {
            if (student == null) return;
            student.Courses.Remove(this);
            Students.Remove(student);
        }
    }
}
