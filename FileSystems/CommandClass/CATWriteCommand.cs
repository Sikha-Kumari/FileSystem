using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class CATWriteCommand : ICommand
    {
        private Operations _operation;

        public CATWriteCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.WriteToFile(args[1], args[2]);
        }
    }
}
