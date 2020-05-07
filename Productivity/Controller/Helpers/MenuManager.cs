using System;
using System.Collections.Generic;
using MenuGenerator;
using Productivity.Controller.Exceptions;

namespace Productivity.Controller.Helpers
{
    public class MenuManager
    {
        private static MenuManager _instance;
        private MenuManager(){}
        private Stack<string> MenuNames { get; } = new Stack<string>();
        private Dictionary<string, IMenuType> Menus { get; } = new Dictionary<string, IMenuType>();
        private IMenuType CurrentMenu { get; set; }

        public void addMenu(string menuName, IMenuType menuToAdd)
        {
            if (MenuNames.Contains(menuName))
                return;

            Menus.Add(menuName, menuToAdd);
            MenuNames.Push(menuName);
            CurrentMenu = menuToAdd;
        }

        // public IMenuType getMenu(string menuName)
        // {
        //     if(!menuNames.Contains(menuName)) throw new MenuDoesNotExistException("Menu doesn't exist in the MenuManager!");
        //
        //     return menus[menuName];
        // }

        public void restorePreviousMenu()
        {
            if(MenuNames.Count == 1)
                throw new MenuStackEmptyException("There is no menu to revert to!");

            MenuNames.Pop();
            CurrentMenu = Menus[MenuNames.Peek()];
        }
        
        public void setCurrentMenu(string menuName)
        {
            if(!menuExists(menuName))
                throw new MenuDoesNotExistException("The given menu does not exist!");
            
            MenuNames.Push(menuName);
            CurrentMenu = Menus[menuName];
        } 
        
        public bool menuExists(string menuName) => MenuNames.Contains(menuName);

        public void draw()
        {
            CurrentMenu.drawMenu();
        }

        public static MenuManager Instance
        {
            get
            {
                return _instance ??= new MenuManager();
            }
        }
    }
}