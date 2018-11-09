using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Items
{
    public interface IInventory
    {
        List<IItem> ItemList { get; set; }

        void AddToList();
        void RemoveFromList();

        void LoadContent();
        void Update();

    }
}
