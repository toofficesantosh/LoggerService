using LoggerLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Model
{
    /// <summary>
    /// Logger Configurations for the Sinks
    /// </summary>
    public class LoggerConfiguration
    {
        public List<ILogSink> Sinks { get; set; }
    }

}
