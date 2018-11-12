using Microsoft.Xna.Framework;
using rpg.Characters;
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

        public void Follow (Player target)
        {
            var offset = Matrix.CreateTranslation(
                Game1.ScreenWidth / 2,
                Game1.ScreenHeight / 2,
                0);
            var position = Matrix.CreateTranslation(
                -target.X - (target._sprite._texture.Width / 2),
                -target.Y - (target._sprite._texture.Height / 2),
                0);

            Transform = position * offset;
        }
    }
}
