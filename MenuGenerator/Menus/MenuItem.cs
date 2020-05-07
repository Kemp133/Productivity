using System;

namespace MenuGenerator
{
    public class MenuItem
    {
        public string menuItem { get; }
        public Action eventToRun { get; }

        public MenuItem(string menuItem, Action eventToRun)
        {
            this.menuItem = menuItem;
            this.eventToRun = eventToRun;
        }
    }
}