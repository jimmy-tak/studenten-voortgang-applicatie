using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace studenten_voortgang_applicatie.Models
{

    internal abstract class Person
    {
        // basic personal information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        // optional user account associated with person
        public const int MinPasswordLength = 4;
        private static HashSet<string> _allUsernames = new HashSet<string>();
        private string? _username;
        public string? Username
        {
            get
            {
                return _username;
            }
            set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username must contain readable characters");
                }
                else if(_allUsernames.Contains(value))
                {
                    throw new ArgumentException("Username must be unique");
                }
                else
                {
                    _username = value;
                    _allUsernames.Add(value);
                }                
            }
        }
        private string? _password;
        public string? Password
        {
            set
            {
                if (value.Length < MinPasswordLength)
                {
                    throw new ArgumentException($"Password must be at least {MinPasswordLength} characters long");
                }
                else
                {
                    _password = value;
                }
            }
        }        
        private List<UserRoles> _roles;

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _roles = new List<UserRoles>();
        }

        public bool HasAccount()
        {
            return Username == null;
        }


        public bool IsAllowedLogin(string username, string password)
        {
            if (_password == null) return false;
            return this.Username == username && _password == password;
        }

        protected void addRole(UserRoles role)
        {
            _roles.Add(role);
        }
        public bool HashRole(UserRoles role)
        {
            return _roles.Contains(role);
        }

        public List<UserRoles> GetRoles()
        {
            return _roles;
        }
    }
}
