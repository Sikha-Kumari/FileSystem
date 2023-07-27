using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems
{
    internal class Invoker
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command, string[] args)
        {
            _commands.Add(command);
            command.Execute(args);
        }
    }
}
