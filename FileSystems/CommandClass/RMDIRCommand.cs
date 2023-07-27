using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class RMDIRCommand : ICommand
    {
        private Operations _operation;

        public RMDIRCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.RemoveDirectory(args[1]);
        }
    }
}
