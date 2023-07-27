using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystems
{
    internal class CommandConfig
    {
        public string Command { get; set; }
        public string CommandClass { get; set; }        
    }

    internal class CommandConfigs
    {
        public List<CommandConfig> CommandConfigList { get; set; }
    }
}
