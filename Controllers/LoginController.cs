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

        private const int _maxLoginAttempts = 3;

        public LoginController(School school, LoginView loginView)
        {
            _school = school;
            _loginView = loginView;            
        }

        public Person Authenticate()
        {
            int loginAttempt = 0;

            while(loginAttempt < _maxLoginAttempts)
            {
                loginAttempt++;

                (string username, string password) = _loginView.GetCredentials();

                // find user in set of all users
                IEnumerable<Person> foundUser = from user in _school.Users
                                                where user.Username == username
                                                select user;

                // if user exists and password is correct
                if (foundUser.Count() == 1 && foundUser.First().ValidateCredential(password))
                {
                    return foundUser.First(); // login success
                }
                else // failed login attempt
                {
                    if (loginAttempt < _maxLoginAttempts)
                    {
                        _loginView.DisplayPressAnyKeyToContinueMessage("Login failed: incorrect username or password.");
                    }                    
                }
            }

            _loginView.DisplayPressAnyKeyToContinueMessage("Access denied.");
            return null; // login failed   
        }        
    }
}
