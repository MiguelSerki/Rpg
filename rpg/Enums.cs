using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public enum ComponentType
    {
        sprite,
        PlayerInput
    }

    public enum Inputs
    {
        Left,
        Right,
        Up,
        Down,
        None
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
    }

    public enum State
    {
        Standing,
        Walking
    }

    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        Quest
    }
}
 