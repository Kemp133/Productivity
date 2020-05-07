using System;
using System.Collections.Generic;

namespace MenuGenerator.Menus
{
    public abstract class MenuBase : IMenuType
    {
        protected List<MenuItem> MenuItems = new List<MenuItem>();
        protected int currentIndex { get; private set; }

        protected MenuBase(IEnumerable<MenuItem> menuItems)
        {
            MenuItems.AddRange(menuItems);
        }
        public abstract void drawMenu();
        
        public void invokeMenuEvent()
        {
            if (MenuItems is null)
                throw new NullReferenceException("No menu items were supplied. Call createMenu() before calling any other menus");
            
            MenuItems[currentIndex].eventToRun.Invoke();
        }

        private bool IsHighlighted { get; set; }

        public void incrementPosition()
        {
            if (!(currentIndex + 1 > MenuItems.Count))
                currentIndex++;
        }

        public void decrementPosition()
        {
            if (!(currentIndex - 1 < 0))
                currentIndex--;
        }

        #region Helper Functions
        protected void HighlightConsole()
        {
            IsHighlighted = !IsHighlighted;
            if (IsHighlighted)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion
    }
}