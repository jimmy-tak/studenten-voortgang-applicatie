using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
using studenten_voortgang_applicatie.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class MenuController
    {
        private Person _user;
        private MenuView _menuView;
        public List<Menu> Menus { get; set; }
        // keep track of the menu's the user has visited so you can return to the previous menu's
        private Stack<Menu> _menuBreadCrumbTrail = new Stack<Menu>();

        public MenuController(Person user, MenuView menuView)
        {
            _user = user;
            Debug.WriteLine($"{user.HasRole(UserRoles.Teacher)}");
            _menuView = menuView;
        }

        public void DisplayMenu(Menus menuId)
        {

            {
                MenuItem chosenMenuItem = _menuView.DisplayMenu(Menus.Where(menu => menu.MenuId == menuId).First(), _user); // link makes finding items in collections very easy               
                
                if (chosenMenuItem != null)
                {
                    // a submenu was chosen
                    if(chosenMenuItem.SubMenuId.HasValue)
                    {
                        _menuBreadCrumbTrail.Push(Menus[(int)menuId]); // push the current menu onto the stack so we can return to it
                        DisplayMenu(chosenMenuItem.SubMenuId.Value); // recursively display the submenu
                    }
                    // a callback was chosen
                    else
                    {
                        chosenMenuItem.Callback(); // call the selected function
                        DisplayMenu(menuId); // display the same menu again
                    }                    
                }
                else
                {
                    // return to the previous menu
                    if (_menuBreadCrumbTrail.Count > 0)
                    {
                        DisplayMenu(_menuBreadCrumbTrail.Pop().MenuId);
                    }
                    // user chose to exit the main menu
                    else
                    {
                        _menuView.DisplayPressAnyKeyToContinueMessage("Exiting application.");
                    }
                }
            }

        }


    }
}
