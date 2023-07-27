using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class MKDIRCommand : ICommand
    {
        private Operations _operation;

        public MKDIRCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.MakeDirectory(args[1]);
        }
    }
}
