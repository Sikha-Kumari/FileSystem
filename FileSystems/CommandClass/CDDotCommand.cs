using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class CDDotCommand : ICommand
    {
        private Operations _operation;

        public CDDotCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.SetParentDirectory(Environment.CurrentDirectory);
        }
    }
}
