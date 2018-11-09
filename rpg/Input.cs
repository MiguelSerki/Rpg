using rpg.MyEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public abstract class Input
    {
        private event EventHandler<NewInputEventsArgs> newInput;
        private double counter;
        private double cooldown;

        public event EventHandler<NewInputEventsArgs> NewInput
        {
            add { newInput += value; }
            remove { newInput -= value; }
        }

        protected Input()
        {
            counter = 0;
            cooldown = 0;
        }

        public void Update(double gameTime)
        {
            if (cooldown > 0)
            {
                counter += gameTime;
                if (counter > gameTime)
                {
                    counter = 0;
                    cooldown = 0;
                }
                else
                {
                    return;
                }
            }
            CheckInput(gameTime);
        }

        protected abstract void CheckInput(double gameTime);

        protected void SendNewInput(Inputs inputs)
        {
            newInput?.Invoke(this, new NewInputEventsArgs(inputs));
        }
    }
}
