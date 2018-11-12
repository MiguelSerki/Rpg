using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg.Components
{
    public class Sprite
    {
        protected Vector2? _position;

        public Texture2D _texture;


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position);
        }


        public Sprite()
        {
        }

        public Sprite(Texture2D texture, Vector2? pos)
        {
            _texture = texture;
            if (pos != null)
            {
                _position = pos;
            }

        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }


    public class Sprite2
    {
        public Texture2D _texture { get; set; }
        public int _height { get; set; }
        public int _width { get; set; }
        public Vector2 _position { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); }
        }

        public Sprite2(Texture2D texture, int width, int height, Vector2 position)
        {
            this._texture = texture;
            this._width = width;
            this._height = height;
            this._position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public void Move(float x, float y, float speed)
        {
            _position = new Vector2(_position.X + (x * speed), _position.Y + (y * speed));
        }

        public void Update(double gameTime)
        {

        }
    }
}