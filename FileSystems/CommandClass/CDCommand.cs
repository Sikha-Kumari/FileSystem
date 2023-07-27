using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class CDCommand : ICommand
    {
        private Operations _operation;

        public CDCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.SetcurrentDirectory(args[1]);
        }
    }
}
