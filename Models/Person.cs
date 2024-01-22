using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using studenten_voortgang_applicatie.Enums;

namespace studenten_voortgang_applicatie.Models
{

    internal class Person
    {
        // basic personal information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        // optional user account associated with person
        public User? User;

        public bool HasAccount()
        {
            return User != null;
        }


    }
}
