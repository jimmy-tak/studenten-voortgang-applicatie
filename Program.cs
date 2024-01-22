using studenten_voortgang_applicatie.Controllers;
using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Authentication;

namespace studenten_voortgang_applicatie
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public Program()
        {
            Console.Title = "Studenten voortgang applicatie";
        }

        public void Run()
        {

             

            Student s = new Student()
            {
                FirstName = "Jan",
                LastName = "Jansen",
                StudentNumber = "1"
   
            };

            User u = new() { Username = "jan", Password = "123" };
            s.User = u;

     

            
            // load data from disk

            // debug data
            HashSet<Person> persons = new HashSet<Person>();
            persons.Add(s);

            // login
            LoginController login = new LoginController(persons);
            try
            {
                Person user = login.Authenticate();
                Console.WriteLine("Welcome");

            } catch (AuthenticationException e)
            {
                Console.WriteLine("nope");
                //exit();
            }
            //login.deconstructor();

            // loop main menu
            //MenuController menu = new MenuController(user);
            //enu.Show();
            

            // end
            
            
            Console.ReadKey();
        }
    }
}
