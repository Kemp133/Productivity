using System.Collections.Generic;
using System.Linq;

namespace MenuGenerator.Menus.Numbered
{
    public abstract class NumberedBase : MenuBase
    {
        protected string ApplyLayout(int num, string val) => $"{num}) {val}";

        protected NumberedBase(IEnumerable<MenuItem> menuItems) : base(menuItems){}

        // public override IMenuType createMenu(IEnumerable<MenuItem> menuItems)
        // {
        //     MenuItems.AddRange(menuItems);
        //     return this;
        // }
    }
}