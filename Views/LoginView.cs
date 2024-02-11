using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class LoginView : BaseView
    {
        // get username and password input
        public (string, string) GetCredentials()
        {
            string username, password;

            Console.Clear();
            username = GetStringInput("username", true);
            password = GetStringInput("password", true);

            return (username, password); // tuple
        }
    }
}
