using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Security.Cryptography;

namespace studenten_voortgang_applicatie.Models
{
    internal class User
    {
        public string Username { get; set; }
        private string? _password;

        public List<Roles> Roles { get; private set; }

        public const int MinPasswordLength = 4;

        public User(string username, string password)
        {
            Username = username;
            SetPassword(password);
            Roles = new List<Roles>();
        }
        public bool AllowLogin(string username, string password)
        {
            if(_password == null) return false;
            return this.Username == username && _password == password;
        }

        public void SetPassword(string password)
        {
            // #todo: hash password
            if(password.Length < User.MinPasswordLength) throw new ArgumentException($"Password must be longer than {User.MinPasswordLength} characters");
            _password = password;
        }

        public void AddRole(Roles role)
        {
            if (Roles.Contains(role)) return;
            Roles.Add(role);
        }

        public void RemoveRole(Roles role)
        {
            Roles.Remove(role);
        }
    }
}
