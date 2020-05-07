using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuGenerator.Menus.Numbered
{
    public class NumberedHorizontal : NumberedBase
    {
        public NumberedHorizontal(IEnumerable<MenuItem> menuItems) : base(menuItems){}

        public override void drawMenu()
        {
            var counter = 0;
            foreach (var mi in MenuItems)
            {
                Console.Write("  ");
                
                if(counter == currentIndex)
                    HighlightConsole();
                
                Console.Write($"{ApplyLayout(counter + 1, mi.menuItem)}  ");
                
                if(counter == currentIndex)
                    HighlightConsole();
                
                counter++;
            }
            Console.WriteLine();
        }
    }
}