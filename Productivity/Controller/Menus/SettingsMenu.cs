using System;
using MenuGenerator;
using Productivity.Controller.Helpers;

namespace Productivity.Controller.Menus
{
    public sealed class SettingsMenu : BaseMenu
    {
        private bool _running = true;
        
        public SettingsMenu(string MenuTitle, string MenuInfo = "") : base(MenuTitle, MenuInfo)
        {
            init();
        }

        protected override void init()
        {
            Menu = Factory.createMenu(MenuTypes.NUMBERED_HORIZONTAL, new[]
            {
                new MenuItem("This is a test", null),
                new MenuItem("Back", back) 
            });
        }

        protected override void start()
        {
            while (_running)
            {
                Console.Clear();
                Menu.drawMenu();

                var key = Console.ReadKey().Key;
                HandleInput(key);
            }
        }

        protected override void end()
        {
            throw new System.NotImplementedException();
        }
        
        private void HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    Menu.incrementPosition();
                    break;
                case ConsoleKey.LeftArrow:
                    Menu.decrementPosition();
                    break;
                case ConsoleKey.Enter:
                    Menu.invokeMenuEvent();
                    break;
            }
        }

        private void back()
        {
            _running = false;
            MenuManager.Instance.restorePreviousMenu();
        }
    }
}