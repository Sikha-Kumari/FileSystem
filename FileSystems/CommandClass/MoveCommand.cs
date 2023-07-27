using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class MoveCommand : ICommand
    {
        private Operations _operation;

        public MoveCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.MoveFile(args[1], args[2]);
        }
    }
}
