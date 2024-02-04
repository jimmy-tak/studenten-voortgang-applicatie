using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studenten_voortgang_applicatie.Views
{
    internal abstract class BaseView
    {
        public void DisplayPressAnyKeyToContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
