using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    //internal class InputKeyboard : Input
    //{
    //    private KeyboardState keyboardState;
    //    private KeyboardState lasKeyboardState;
    //    private Keys lastKey;

    //    protected override void CheckInput(double gameTime)
    //    {
    //        keyboardState = Keyboard.GetState();
    //        if (keyboardState.IsKeyUp(lastKey) && lastKey != Keys.None)
    //        {
    //            SendNewInput(Inputs.None);
    //        }

    //        CheckKeyState(Keys.Left, Inputs.Left);
    //        CheckKeyState(Keys.Up, Inputs.Up);
    //        CheckKeyState(Keys.Right, Inputs.Right);
    //        CheckKeyState(Keys.Down, Inputs.Down);

    //        lasKeyboardState = keyboardState;
    //    }

    //    private void CheckKeyState(Keys key, Inputs sendInputs)
    //    {
    //        if (keyboardState.IsKeyDown(key))
    //        {
    //            SendNewInput(sendInputs);
    //            lastKey = key;
    //        }
    //    }
    //}
}
