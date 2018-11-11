using rpg.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Items
{
    [System.Serializable]
    public class Item : IItem
    {
        //    public string Tooltip { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public Sprite Image { get; set; }

        //public ItemType itemType;

    }
}
