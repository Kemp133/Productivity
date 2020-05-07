using System;
using System.Collections.Generic;
using System.Linq;
using MenuGenerator.Menus.Numbered;

namespace MenuGenerator
{
    public class MenuFactory
    {
        public IMenuType createMenu(MenuTypes type, IEnumerable<MenuItem> menuItems)
        {
            //Create IMenuType ready to initialise with the correct menu
            IMenuType menu = null;
            //Used to stop multiple enumeration error (though I shouldn't have to worry about that personally)
            var enumerable = menuItems.ToList();

            //Iterate through each menu item. If any are null, empty "", or whitespace " ... ", then throw an exception
            //to alert the user that their input is not valid
            foreach (var s in enumerable.Where(s => string.IsNullOrEmpty(s.menuItem) || string.IsNullOrWhiteSpace(s.menuItem)))
                throw new ArgumentException($"The passed values contain a value which is not valid, '{s}'! Correct this erroneous value before continuing");
            
            //Now pattern match the input against all the menu types to instantiate the correct menu
            switch (type)
            {
                case MenuTypes.NUMBERED_HORIZONTAL:
                    menu = new NumberedHorizontal(enumerable);
                    break;
                case MenuTypes.NUMBERED_VERTICAL:
                    menu = new NumberedVertical(enumerable);
                    break;
                case MenuTypes.ANGLE_HORIZONTAL:
                    break;
                case MenuTypes.ANGLE_VERTICAL:
                    break;
                case MenuTypes.SQUARE_HORIZONTAL:
                    break;
                case MenuTypes.SQUARE_VERTICAL:
                    break;
                default:
                    throw new Exception("Menu type not coded for");
            }

            return menu;
        }
    }
}