using rpg.Components;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg.Characters
{
    public class Player
    {
        public Sprite _sprite { get; set; }

        public double Speed = 150;
        public Input Input;
        public Vector2 Velocity;

        public float X { get; set; }
        public float Y { get; set; }

        Animation walkLeft;
        Animation walkRight;
        Animation standLeft;
        Animation standRight;

        Animation attack;

        Animation currentAnimation;

        public Player(GraphicsDevice graphicsDevice)
        {
            Input = new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Right = Keys.D,
                Left = Keys.A,
                None = Keys.None,
                Attack = Keys.K
            };
            _sprite = new Sprite();
        }

        public void LoadContent(Sprite sprite)
        {
            this._sprite = sprite;

            walkLeft = new Animation();

            walkLeft.AddFrame(new Rectangle(0, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(48, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(96, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(144, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(192, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(240, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(288, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(336, 49, 48, 49), TimeSpan.FromSeconds(.125));

            walkRight = new Animation();
            walkRight.AddFrame(new Rectangle(336, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(288, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(240, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(192, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(144, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(96, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(48, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(0, 245, 48, 49), TimeSpan.FromSeconds(.125));


            standLeft = new Animation();

            standLeft.AddFrame(new Rectangle(0, 0, 48, 49), TimeSpan.FromSeconds(.25));
            standLeft.AddFrame(new Rectangle(48, 0, 48, 49), TimeSpan.FromSeconds(.25));
            standLeft.AddFrame(new Rectangle(96, 0, 48, 49), TimeSpan.FromSeconds(.25));
            standLeft.AddFrame(new Rectangle(144, 0, 48, 49), TimeSpan.FromSeconds(.25));

            standRight = new Animation();
            standRight.AddFrame(new Rectangle(336, 0, 48, 49), TimeSpan.FromSeconds(.25));
            standRight.AddFrame(new Rectangle(288, 0, 48, 49), TimeSpan.FromSeconds(.25));
            standRight.AddFrame(new Rectangle(240, 0, 48, 49), TimeSpan.FromSeconds(.25));
            standRight.AddFrame(new Rectangle(192, 0, 48, 49), TimeSpan.FromSeconds(.25));

            attack = new Animation();

            attack.AddFrame(new Rectangle(0, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(48, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(96, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(144, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(192, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(240, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(288, 98, 48, 49), TimeSpan.FromSeconds(.050));
            attack.AddFrame(new Rectangle(336, 98, 48, 49), TimeSpan.FromSeconds(.050));

        }

        public void Update(GameTime gameTime)
        {

            Move();
            this.X += Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.Y += Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (Velocity != Vector2.Zero)
            {
                    if (Velocity.X > 0)
                    {
                        currentAnimation = walkRight;
                    }
                    else
                    {
                        currentAnimation = walkLeft;
                    }

                if (Velocity.Y > 0)
                {
                    if (currentAnimation == walkRight || currentAnimation == standRight)
                        currentAnimation = walkRight;
                    else
                        currentAnimation = walkLeft;
                }
                else
                {
                    if (currentAnimation == walkRight || currentAnimation == standRight)
                        currentAnimation = walkRight;
                    else
                        currentAnimation = walkLeft;
                }
            }
        
            else
            {
                // If the character was walking, we can set the standing animation
                // according to the walking animation that is playing:
                if (currentAnimation == walkRight)
                {
                    currentAnimation = standRight;
                }
                else if (currentAnimation == walkLeft)
                {
                    currentAnimation = standLeft;
                }
                else if (currentAnimation == null)
                {
                    currentAnimation = standRight;
                }

                if (Keyboard.GetState().IsKeyDown(Input.Attack))
                {
                    currentAnimation = attack;
                }

                // if none of the above code hit then the character
                // is already standing, so no need to change the animation.
            }


            currentAnimation.Update(gameTime);

            _sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(_sprite._texture, topLeftOfSprite, sourceRectangle, Color.White);
        }

        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = (float)-Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = (float)Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = (float)-Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = (float)Speed;
            if (Keyboard.GetState().IsKeyUp(Input.Up) && Keyboard.GetState().IsKeyUp(Input.Down))
            {
                Velocity.Y = 0;
            }
            if (Keyboard.GetState().IsKeyUp(Input.Left) && Keyboard.GetState().IsKeyUp(Input.Right))
            {
                Velocity.X = 0;
            }

        }
    }
}