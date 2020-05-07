using System.Collections.Generic;

namespace MenuGenerator
{
    public interface IMenuType
    {
        // public IMenuType createMenu(IEnumerable<MenuItem> menuItems);
        public void drawMenu();
        public void incrementPosition();
        public void decrementPosition();
        public void invokeMenuEvent();
    }
}