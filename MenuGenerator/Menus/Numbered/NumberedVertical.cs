using System;
using System.Collections.Generic;

namespace MenuGenerator.Menus.Numbered
{
    public class NumberedVertical : NumberedBase
    {
        public NumberedVertical(IEnumerable<MenuItem> menuItems) : base(menuItems){}

        public override void drawMenu()
        {
            MenuItems.ForEach(i => Console.WriteLine($"  {i}"));
        }
    }
}