using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
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
        private List<Menu> _menus;
        private Stack<Menu> _menuBreadCrumbTrail;
        private MenuView _menuView;

        public MenuController(Person user, MenuView menuView)
        {
            _user = user;
            _menuView = menuView;
            _menus = new List<Menu>();
            _menuBreadCrumbTrail = new Stack<Menu>();
        }
        public void AddMenu(Menu menu)
        {
            _menus.Add(menu);
        }

        public void SetMainMenu(Menu menu)
        {
            _menuBreadCrumbTrail.Push(menu);
        }


        public void DisplayCurrentMenu()
        {
            MenuItem chosenMenuItem = _menuView.DisplayMenu(_menuBreadCrumbTrail.Pop());
            if (chosenMenuItem != null)
            {
                if(_menuBreadCrumbTrail.Count > 0)
                {
                    MenuItem chosenMenuItem2 = _menuView.DisplayMenu(_menuBreadCrumbTrail.Pop());
                }
                else
                {
                    // exit application?
                }
            }
            else
            {

            }
        }
    }
}
