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

        public float Speed = 1f;
        public Input Input;
        public Vector2 Velocity;

        public float X { get; set; }
        public float Y { get; set; }

        Animation walkLeft;
        Animation walkRight;
        Animation standLeft;
        Animation standRight;

        Animation currentAnimation;


        //       private InputKeyboard _inputKeyboard { get; set; }

        public Player(GraphicsDevice graphicsDevice)
        {
            //_inputKeyboard = new InputKeyboard();
            //_inputKeyboard.NewInput += InputKeyboard_NewInput;
            Input = new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Right = Keys.D,
                Left = Keys.A
            };
            _sprite = new Sprite();
        }

        public void LoadContent(Sprite sprite)
        {
            this._sprite = sprite;

            walkLeft = new Animation();
            walkLeft.AddFrame(new Rectangle(48, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(96, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(144, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(192, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(240, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(288, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(336, 49, 48, 49), TimeSpan.FromSeconds(.125));
            walkLeft.AddFrame(new Rectangle(384, 49, 48, 49), TimeSpan.FromSeconds(.125));

            walkRight = new Animation();
            walkRight.AddFrame(new Rectangle(384, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(336, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(288, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(240, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(192, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(144, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(96, 245, 48, 49), TimeSpan.FromSeconds(.125));
            walkRight.AddFrame(new Rectangle(48, 245, 48, 49), TimeSpan.FromSeconds(.125));








            standLeft = new Animation();
            standLeft.AddFrame(new Rectangle(48, 0, 48, 49), TimeSpan.FromSeconds(.25));

            standRight = new Animation();
            standRight.AddFrame(new Rectangle(96, 0, 48, 49), TimeSpan.FromSeconds(.25));


        }

        public void Update(GameTime gameTime)
        {

            _sprite.Update(gameTime);
            Move();
            this.X += Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.Y += Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (Velocity != Vector2.Zero)
            {
                bool movingHorizontally = Math.Abs(Velocity.X) > Math.Abs(Velocity.Y);
                if (movingHorizontally)
                {
                    if (Velocity.X > 0)
                    {
                        currentAnimation = walkRight;
                    }
                    else
                    {
                        currentAnimation = walkLeft;
                    }
                }
                //else
                //{
                //    if (velocity.Y > 0)
                //    {
                //        currentAnimation = walkDown;
                //    }
                //    else
                //    {
                //        currentAnimation = walkUp;
                //    }
                //}
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

                // if none of the above code hit then the character
                // is already standing, so no need to change the animation.
            }

            currentAnimation.Update(gameTime);


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
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;
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