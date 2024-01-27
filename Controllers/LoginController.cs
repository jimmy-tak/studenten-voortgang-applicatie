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
            int loginAttempt = 0;

            while (loginAttempt < _maxNumAttempts)
            {
                loginAttempt++;

                (string username, string password) = _loginView.GetCredentials();

                // find user in set of all users
                IEnumerable<Person> foundUser = from user in _school.Users
                                                where user.Username == username
                                                select user;

                if (foundUser.Count() == 1 && foundUser.First().ValidateCredential(password))
                {
                    return foundUser.First();
                }
                else
                {
                    if (loginAttempt < _maxNumAttempts)
                    {
                        _loginView.DisplayLoginFailureMessage();
                    }                    
                }
            }

            _loginView.DisplayAccessDeniedMessage();
            return null; // login failed   
        }        
    }
}
