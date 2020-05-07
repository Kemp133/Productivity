using System.Collections.Generic;
using MenuGenerator;

namespace Productivity.Controller.Menus
{
    /// <summary>
    /// This class is used as a base for the other menu's. While probably the product of over-engineering, it attempts
    /// to follow good coding practices anyways and provide a nice way to expand functionality in the future without
    /// much need for extensive programming 
    /// </summary>
    public abstract class BaseMenu
    {
        protected BaseMenu(string MenuTitle, string MenuInfo = "")
        {
            this.MenuTitle = MenuTitle;
            this.MenuInfo = MenuInfo;
        }

        protected MenuFactory Factory = new MenuFactory();

        protected string MenuHeader { get; set; }

        /// <summary>
        /// A IMenuType reference which stores the specific menu for a given menu. Moved here because all menus will
        /// need to have this variable anyways. Has a protected set as you don't want external classes to be able to
        /// change this variable
        /// </summary>
        public IMenuType Menu { get; protected set; }
        // /// <summary>
        // /// A set of strings used to store the values for the menu items (and hence by the nature of a set lead to no
        // /// duplicates. Hash variant used for speed. Only expose a get method too, as I'm practicing using immutable
        // /// coding standards
        // /// </summary>
        // protected HashSet<string> MenuItems { get; }
        /// <summary>
        /// A specific string for the title of the menu
        /// </summary>
        public string MenuTitle { get; }
        /// <summary>
        /// A specific string for the info portion of the menu
        /// </summary>
        public string MenuInfo { get; }

        /// <summary>
        /// This method is called when the constructor of the menu is called, meaning all newly created menus are
        /// initialised
        /// </summary>
        protected abstract void init();
        /// <summary>
        /// This method should contain the main body of the code (i.e. menu creation, dealing with input, etc...) as
        /// well as the loop that keeps the program trapped in that menu. Called after init() and before end()
        /// </summary>
        protected abstract void start();
        /// <summary>
        /// This method should deal with any logic that is needed after the menu has outlived it's usefulness, and clean
        /// up any data structures which were created in the menu's
        /// </summary>
        protected abstract void end();

        /// <summary>
        /// This method should be called to run a given window. Calls init(), then start(), and then end()
        /// </summary>
        public void run()
        {
            start();
            end();
        }
    }
}