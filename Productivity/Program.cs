using System;
using Productivity.Controller.Helpers;
using Productivity.Controller.Menus;
using rl = Productivity.Controller.Helpers.ResourceLoader;

namespace Productivity
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"\res\app.config");
            SetWindowSize();
            var menu = new MainMenu("Main Menu");
            MenuManager.Instance.addMenu("Main Menu", menu.Menu);
            menu.run();
        }

        private static void SetWindowSize()
        {
            int width, height;
            try
            {
                width = rl.GetResourceAs<int>("consoleWidth");
                height = rl.GetResourceAs<int>("consoleHeight");
            }
            catch (Exception)
            {
                width = 120;
                height = 30;
            }
            Console.SetWindowSize(width, height);
        }
    }
}