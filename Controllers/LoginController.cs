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
        private HashSet<Person> users;
        public LoginController(HashSet<Person> users) 
        {
            this.users = users;
        }

        public Person Authenticate()
        {
            string username, password;
            Console.Write("username: ");
            username = Console.ReadLine();
            Console.Write("password: ");
            password = Console.ReadLine();

            // linq functie voor zoeken gebruiker
            return null;
        }
        
    }
}
