using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Models
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public Role role

        // only for users
        public string? Username { get; set; }
        public string? Password { get; set; }


        private const int minPasswordLength = 4;

        public Person(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Username = username;
        }

    }
}
