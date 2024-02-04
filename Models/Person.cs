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
        public string FullName { get => LastName + ", " + FirstName; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // account related properties (optional)
        public const int MinPasswordLength = 4;
        private static HashSet<string> _allUsernames = new HashSet<string>(); // to prevent duplicate usernames

        private string? _username;
        public string? Username
        {
            get => _username;
            set 
            {
                if(value == null)  // allow account to be deleted
                {
                    _username = null;
                }
                else if (String.IsNullOrWhiteSpace(value))
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
                if (value != null && value.Length < MinPasswordLength)
                {
                    throw new ArgumentException($"Password must be at least {MinPasswordLength} characters long");
                }
                else
                {
                    // should hash or encrypt password
                    _password = value;
                }
            }
        }        
        private List<UserRoles> _roles;
        public List<UserRoles> Roles { get => _roles; }


        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _roles = new List<UserRoles>();
        }

        public bool HasAccount()
        {
            return Username != null;
        }

        public bool ValidateCredential(string password)
        {
            return _password == password;
        }

        protected void addRole(UserRoles role)
        {
            _roles.Add(role);
        }
        public bool HasRole(UserRoles role)
        {
            return _roles.Contains(role);
        }


    }
}
