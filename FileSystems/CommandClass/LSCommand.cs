using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems.CommandClass
{
    internal class LSCommand : ICommand
    {
        private Operations _operation;

        public LSCommand(Operations operation)
        {
            _operation = operation;
        }

        public void Execute(string[] args)
        {
            _operation.GetDirectoryAndFiles(Environment.CurrentDirectory);
        }
    }
}
