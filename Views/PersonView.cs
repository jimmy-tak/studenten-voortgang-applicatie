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
        public Person GetPersonDetails(bool required = false)
        {
            string lastName, firstName, email, street, postalCode, city;
            DateTime dateOfBirth;

            lastName = GetStringInput("Last name", required);
            firstName = GetStringInput("First name", required);
            dateOfBirth = GetDateTimeInput("Date of birth");
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
