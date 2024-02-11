using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Result
    {


        public Course Course { get; private set; }
        public float Grade { get; private set; }

        public Result(Course course, float grade)
        {
            if (grade < 0f || grade > 10f)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 10");
            }
            else
            {
                Course = course;
                Grade = grade;
            }
        }

        }
    }

