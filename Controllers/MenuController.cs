using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Views;
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
        private Stack<Menu> _menuBreadCrumbTrail = new Stack<Menu>();

#if DEBUG
        static int RecursionCounter = 0;
#endif


        public MenuController(Person user, MenuView menuView)
        {
            _user = user;
            _menuView = menuView;
        }

        public void DisplayMenu(int id)
        {
#if DEBUG
            Debug.WriteLine($"DisplayMenu recursion counter: {++RecursionCounter}");
#endif

            {
                MenuItem chosenMenuItem = _menuView.DisplayMenu(Menus.Where(menu => menu.Id == id).First(), _user); // linq feels like cheating                
                
                if (chosenMenuItem != null)
                {
                    if(chosenMenuItem.SubMenuId.HasValue)
                    {
                        _menuBreadCrumbTrail.Push(Menus[id]); // push previous menu onto the stack so we can return to it
                        DisplayMenu(chosenMenuItem.SubMenuId.Value);  // recursion hopefully works out here
                    }
                    else // if(chosenMenuItem.Callback != null)
                    {
                        chosenMenuItem.Callback(); // may be null but should not be null
                        DisplayMenu(id); // back to the same menu
                    }                    
                }
                else
                {
                    if (_menuBreadCrumbTrail.Count > 0)
                    {
                        DisplayMenu(_menuBreadCrumbTrail.Pop().Id);
                    }
                    else
                    {
                        Console.WriteLine("exiting");
                    }
                }
            }
#if DEBUG
            RecursionCounter--;
#endif
        }


    }
}
