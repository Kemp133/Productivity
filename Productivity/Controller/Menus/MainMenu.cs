using System;
using System.Linq;
using MenuGenerator;
using Productivity.Controller.Helpers;
using rl = Productivity.Controller.Helpers.ResourceLoader;

namespace Productivity.Controller.Menus
{
	public sealed class MainMenu : BaseMenu
	{

		private bool _running = true;

		public MainMenu(string title, string info = "") : base(title, info)
		{
			MenuHeader = @"______              _            _   _       _ _         
| ___ \            | |          | | (_)     (_) |        
| |_/ / __ ___   __| |_   _  ___| |_ ___   ___| |_ _   _ 
|  __/ '__/ _ \ / _` | | | |/ __| __| \ \ / / | __| | | |
| |  | | | (_) | (_| | |_| | (__| |_| |\ V /| | |_| |_| |
\_|  |_|  \___/ \__,_|\__,_|\___|\__|_| \_/ |_|\__|\__, |
                                                    __/ |
                                                   |___/";
			init();
		}

		protected override void init()
		{
			Menu = Factory.createMenu(MenuTypes.NUMBERED_HORIZONTAL, new[]
			{
				new MenuItem(rl.GetResourceAs<string>("mainMenu_ViewAllTasks"), null),
				new MenuItem(rl.GetResourceAs<string>("mainMenu_AddTask"), null),
				new MenuItem(rl.GetResourceAs<string>("mainMenu_EditTask"), null),
				new MenuItem("Settings", LoadSettingsMenu),
				new MenuItem(rl.GetResourceAs<string>("mainMenu_Exit"), () => _running = false)
			});
		}

		protected override void start()
		{
			while (_running)
			{
				Console.Clear();
				MenuManager.Instance.draw();

				var key = Console.ReadKey().Key;
				HandleInput(key);
			}
		}

		protected override void end()
		{
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

		private void LoadSettingsMenu()
		{
			var manager = MenuManager.Instance;

			if (manager.menuExists("Settings"))
			{
				manager.setCurrentMenu("Settings");
				return;
			}

			manager.addMenu("Settings", 
				new SettingsMenu("Settings",
					"Where all of the settings are stored").Menu);
		}
	}
}