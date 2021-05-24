using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Invoker
    {
        private List<ICommand> commands = new List<ICommand>();

        public Invoker()
        {
            commands.Add(new TalkCommand());
            commands.Add(new SingCommand());
        }

        public void ExecuteCommands(Receiver receiver)
        {
            foreach (ICommand command in commands)
            {
                command.Execute(receiver);
            }
        }
    }
}
