using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_Databasprojekt
{
    internal class Arrowmenu
    {
        public static int startMenuArrow(List<string> MenuList, string message)
        {

            int menuSelected = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine("\n\tGör ditt val med piltangenterna och tryck Enter för att välja:\n");
                for (int i = 0; i < MenuList.Count; i++)
                {
                    if (menuSelected == i)
                    {
                        Console.WriteLine("-->" + MenuList[i]);
                    }
                    else
                    {
                        Console.WriteLine(MenuList[i]);
                    }
                }
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != MenuList.Count - 1)
                {
                    menuSelected++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected >= 1)
                {
                    menuSelected--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    return menuSelected;
                }
            }
        }
    }
}
