using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal class PersonView : BaseView
    {
        public void DisplayPersonDetails(Person person)
        {
            Console.WriteLine($"Last name\t: {person.LastName}");
            Console.WriteLine($"First name\t: {person.FirstName}");
            string dateOfBearth = person.DateOfBirth != DateTime.MinValue ? person.DateOfBirth.ToString("d-M-yyyy") : "";
            Console.WriteLine($"Date of birth\t: {dateOfBearth}");
            Console.WriteLine($"Email\t\t: {person.Email}");
            Console.WriteLine($"Street\t\t: {person.Street}");
            Console.WriteLine($"Postal code\t: {person.PostalCode}");
            Console.WriteLine($"City\t\t: {person.City}");
            //Console.WriteLine($"Username\t: {person.Username}");
        }

        public Person GetPersonDetails(bool required = false)
        {
            string lastName, firstName, email, street, postalCode, city;
            DateTime dateOfBirth;

            lastName = GetStringInput("Last name", required);
            firstName = GetStringInput("First name", required);
            dateOfBirth = BaseView.GetDateTimeInput("Date of birth");
            email = GetStringInput("Email");
            street = GetStringInput("Street");
            postalCode = GetStringInput("Postal code");
            city = GetStringInput("city");

            return new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                Street = street,
                PostalCode = postalCode,
                City = city
            };
        }
    }
}
