using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class LoginView
    {
        public (string, string) GetCredentials()
        {
            string username, password;

            Console.Clear();
            Console.Write("username: ");
            username = Console.ReadLine();
            Console.Write("password: ");
            password = Console.ReadLine();
            return (username, password);
        }
    }
}
