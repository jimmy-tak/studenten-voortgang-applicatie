using studenten_voortgang_applicatie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class MenuController
    {
        private Person _user;
        private Menu _currentMenu;

        // othercontrollers

        // addmenu
        // addmenuitem(menu, menuitem)
        public MenuController(Person user)
        {
            _user = user;
        }
        public void AddMenu(Menu menu)
        {

        }

    }
}
