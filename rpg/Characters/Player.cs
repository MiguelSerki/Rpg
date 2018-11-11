using rpg.Components;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace rpg.Characters
{
    public class Player
    {
        public Sprite _sprite { get; set; }
        public Sprite cameraFollow;
 //       private InputKeyboard _inputKeyboard { get; set; }

        public float _speed { get; set; }
        public Player()
        {
            //_inputKeyboard = new InputKeyboard();
            //_inputKeyboard.NewInput += InputKeyboard_NewInput;
           // _sprite = new Sprite();
            cameraFollow = new Sprite(new Texture2D(Game1.Instance.GraphicsDevice, 100,100));
            _speed = 5;
        }

        public void LoadContent(Sprite sprite)
        {
            this._sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            //          _inputKeyboard.Update(gameTime);
            _sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        //private void InputKeyboard_NewInput(object sender, MyEventArgs.NewInputEventsArgs e)
        //{
        //    switch (e.input)
        //    {
        //        case Inputs.Up:
        //            if (_sprite._position.Y <= 0)
        //            {
        //                this._sprite.Move(0, 0, _speed);
        //            }
        //            else
        //            {
        //                this._sprite.Move(0, -1.5f, _speed);
        //            }

        //            break;
        //        case Inputs.Down:

        //            if ((float)_sprite._height + _sprite._position.Y >= Game1.LimitHeight)
        //            {
        //                this._sprite.Move(0, 0, _speed);
        //            }
        //            else
        //            {
        //                this._sprite.Move(0, 1.5f, _speed);
        //            }

        //            break;
        //        case Inputs.Left:

        //            if (_sprite._position.X > 0)
        //            {
        //                this._sprite.Move(-1.5f, 0, _speed);
        //            }
        //            else
        //            {
        //                this._sprite.Move(0, 0, _speed);
        //            }

        //            break;
        //        case Inputs.Right:
        //            if ((float)_sprite._width + _sprite._position.X >= Game1.LimitWidth)
        //            {
        //                this._sprite.Move(0, 0, _speed);
        //            }
        //            else
        //            {
        //                this._sprite.Move(1.5f, 0, _speed);
        //            }
        //            break;
        //        case Inputs.None:
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}
    }
}