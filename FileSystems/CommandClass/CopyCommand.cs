using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class CopyCommand : ICommand
    {
        private Operations _operation;

        public CopyCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.CopyFile(args[1], args[2]);
        }
    }
}
