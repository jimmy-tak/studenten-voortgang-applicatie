using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Enrollment
    {
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
