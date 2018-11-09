using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Items
{
    public class Inventory : IInventory
    {
        public List<IItem> ItemList { get; set; }


        public Inventory()
        {
            ItemList = new List<IItem>();
        }
        public Inventory (List<IItem> list)
        {
            ItemList = list;
        }

        public void AddToList()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromList()
        {
            throw new NotImplementedException();
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
