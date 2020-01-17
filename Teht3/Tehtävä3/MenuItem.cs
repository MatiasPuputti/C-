//Matias Puputti 10.11.2019
using System;

namespace Tehtävä3
{
    class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public event EventHandler<MenuItemEventArgs> ItemSelected;
        public void Select()
        {
            ItemSelected(this, new MenuItemEventArgs { Itemid = Id });
        }
        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
