using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class LoginController
    {
        private readonly School _school;
        private readonly LoginView _loginView;

        private const int _maxNumAttempts = 3;

        public LoginController(LoginView loginView, School school)
        {
            _loginView = loginView;
            _school = school;
        }


        public Person Authenticate()
        {
            (string username, string password) = _loginView.GetCredentials();
/*
            var users = from user in _school.Users
                        where user.Username == username
                        select user;

            if(users.Count() == 1 )
            {
                Console.WriteLine(users.First());
            }
            else
            {
                return null;
            }
*/
            return null;

        }
        
    }
}
