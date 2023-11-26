using LoggerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Interface
{
    // Sink interface 
    public interface ILogSink
    {
        /// <summary>
        /// This method will be used to log the messages in the sink
        /// </summary>
        /// <param name="message">Log message details</param>
        void LogMessage(LogMessage message);
    }
}
