using LoggerClient.Model;
using LoggerLibrary.Implementation;
using LoggerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerLibrary.Model;
using Newtonsoft.Json;
using LoggerLibrary.Manager;

namespace LoggerClient.Services
{
    /// <summary>
    /// To consume the Logger Library
    /// </summary>
    internal sealed class LoggerService
    {
        private static readonly LoggerConfiguration loggerConfiguration;
        private static readonly Logger logger;

        static LoggerService()
        {
            // To initialize loggerConfiguration only if it's null
            loggerConfiguration = loggerConfiguration ?? LoggerConfiguration();

            // Use the Logger.GetInstance method directly in the assignment
            logger = Logger.GetInstance(loggerConfiguration);
        }
        
        #region Methods

        /// <summary>
        /// Logs a message with the specified level, namespace, and content.
        /// </summary>
        /// <param name="level">The log level of the message.</param>
        /// <param name="namespaceValue">The namespace of the message.</param>
        /// <param name="content">The content of the message.</param>
        internal static void LogMessage(LogLevel level, string namespaceValue, string content)
        {
            // Create a LogMessage instance using an object initializer
            var message = new LogMessage
            {
                Level = level,
                Namespace = namespaceValue,
                Content = content
            };

            // Delegate the logging responsibility to the logger instance
            logger.LogMessage(message);
        }

        /// <summary>
        /// Reads the logger configuration from a file and initializes sinks.
        /// </summary>
        /// <returns>The initialized logger configuration.</returns>
        private static LoggerConfiguration LoggerConfiguration()
        {
            // Read configuration from file
            var configuration = LogManager.ReadConfiguration(AppConstant.LOGFILECONFIG);

            // Initialize sinks based on configuration
            var sinks = LogManager.InitializeSinks(configuration);

            // Use object initializer for LoggerConfiguration
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration
            {
                Sinks = sinks
            };

            return loggerConfiguration;
        }
        #endregion
    }
}
