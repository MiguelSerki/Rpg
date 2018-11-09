using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Components
{
    public class Camera
    {
        public Matrix Transform { get; set; }

        public void Follow (Sprite target)
        {
            var offset = Matrix.CreateTranslation(
                Game1.ScreenWidth / 2,
                Game1.ScreenHeight / 2,
                0);
            var position = Matrix.CreateTranslation(
                -target._position.X - (target.Rectangle.Width / 2),
                -target._position.Y - (target.Rectangle.Height / 2),
                0);

            Transform = position * offset;
        }
    }
}
