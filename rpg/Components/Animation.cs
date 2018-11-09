using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rpg.Components
{
    public class Animation
    {

        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public int FrameHeight { get; set; }
        public int FrameWidth { get; set; }
        public float FrameSpeed { get; set; }
        public bool IsLooping { get; set; }
        public Texture2D Texture { get; private set; }
       

        public Animation(Texture2D texture, int frameCount)
        {
            Texture = texture;
            FrameCount = frameCount;
            IsLooping = true;

            FrameSpeed = 0.2f;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        
        }

    }
}
