using studenten_voortgang_applicatie.Controllers;
using System;

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
            // login
            // loop main menu

            Console.WriteLine("Hello World");
            Console.ReadKey();
        }
    }
}
