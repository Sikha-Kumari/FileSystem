﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems
{
    public interface ICommand
    {
        void Execute(string[] args);
    }
}
