using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class CATReadCommand : ICommand
    {
        private Operations _operation;

        public CATReadCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.ReadFile(args[1]);
        }
    }
}
