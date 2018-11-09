using rpg.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Items
{
    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        string Description { get; set; }
        Sprite Image { get; set; }

    }
}
