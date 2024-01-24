using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using studenten_voortgang_applicatie.Controllers;
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
            School school = CreateSampleData();

            LoginController loginController = new LoginController(new LoginView(), school);

            Person user = loginController.Authenticate();

            if(user == null)



            //Menu mainMenu = new Menu("Hoofdmenu");

            //MenuController menuController = new MenuController();
            //MenuController.DisplayMenu(mainMenu, user);


            Console.ReadKey();
        }

        private School CreateSampleData()
        {
            School school = new School("Curio", "25LX");
            Employee employee = new Employee("Jimmy", "Tak");
            employee.Username = "jimmy";

        }
        private void CreateMenus()
        {

        }


    }
}
