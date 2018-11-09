using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.MyEventArgs
{
    public class NewInputEventsArgs: EventArgs
    {
        public Inputs input { get; set; }

        public NewInputEventsArgs(Inputs input)
        {
            this.input = input;
        }
    }
}
