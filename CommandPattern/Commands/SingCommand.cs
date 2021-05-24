using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class SingCommand : ICommand
    {
        public void Execute(Receiver receiver)
        {
            if (!receiver.IsMute)
            {
                receiver.Say("I am singing!");
            }
            else
            {
                receiver.Say("I tried to sing, but I am mute.");
            }
        }
    }
}
