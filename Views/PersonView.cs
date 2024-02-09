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
        public Person CreatePerson()
        {
            string lastName, firstName, email, street, postalCode, city;
            DateTime dateOfBirth;

            lastName = GetStringInput("Last name (required)", true);
            firstName = GetStringInput("First name (required)", true);
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
