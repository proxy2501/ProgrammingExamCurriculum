using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class TalkCommand : ICommand
    {
        public void Execute(Receiver receiver)
        {
            if (!receiver.IsMute)
            {
                receiver.Say("I am talking.");
            }
            else
            {
                receiver.Say("I tried to talk, but I am mute.");
            }
        }
    }
}
