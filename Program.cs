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
            Program StudentenVoortgangApplicatie = new Program();
            StudentenVoortgangApplicatie.Run();
        }

        public Program()
        {
            Console.Title = "Studenten voortgang applicatie";
        }

        public void Run()
        {
            // load data from disk

            // debug data
            HashSet<Person> persons = new HashSet<Person>();
            persons.Add(new Person("Jimmy", "Tak", "jtak", "1234"));

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
