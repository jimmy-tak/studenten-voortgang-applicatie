using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using studenten_voortgang_applicatie.Models;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class LoginController
    {
        private readonly HashSet<Person> _users;
        public LoginController(HashSet<Person> users) 
        {
            this._users = users;
        }

        public Person Authenticate()
        {
            string username, password;
            Console.Write("username: ");
            username = Console.ReadLine();
            Console.Write("password: ");
            password = Console.ReadLine();

            var founduser = from u in _users
                            where u.Username == username
                            select u;

            if(founduser.Count() == 1 )
            {
                Console.WriteLine(founduser.First().FirstName);
            }
            else
            {
                return null;
            }
            return null;

        }
        
    }
}
