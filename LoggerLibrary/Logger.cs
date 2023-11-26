using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using LoggerLibrary.Implementation;

namespace LoggerLibrary
{
    /// <summary>
    /// Represents a logger responsible for logging messages to configured sinks.
    /// </summary>
    public class Logger
    {
        private static Logger instance;
        private static readonly object lockObject = new object();

        private LoggerConfiguration configuration;

        /// <summary>
        /// Private constructor to initialize the logger with the provided configuration.
        /// </summary>
        /// <param name="configuration">The logger configuration.</param>
        private Logger(LoggerConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        /// <summary>
        /// Gets the singleton instance of the Logger.
        /// </summary>
        /// <param name="configuration">The logger configuration.</param>
        /// <returns>The singleton instance of the Logger.</returns>
        public static Logger GetInstance(LoggerConfiguration configuration)
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Logger(configuration);
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Logs the specified message to all configured sinks.
        /// </summary>
        /// <param name="message">The log message to be logged.</param>
        public void LogMessage(LogMessage message)
        {
            foreach (var sink in configuration.Sinks)
            {
                // Check if the sink is configured for the specified level
                if (IsSinkConfiguredForLevel(sink, message.Level))
                {
                    sink.LogMessage(message);
                }
            }
        }

        /// <summary>
        /// Checks if the specified sink is configured to log messages for the specified log level.
        /// </summary>
        /// <param name="sink">The log sink to check.</param>
        /// <param name="level">The log level to check configuration for.</param>
        /// <returns>True if the sink is configured for the specified level; otherwise, false.</returns>
        private bool IsSinkConfiguredForLevel(ILogSink sink, LogLevel level)
        {
            // Check if the sink implements ISinkConfigurable
            if (sink is ISinkConfigurable logLevelConfigurableSink)
            {
                return logLevelConfigurableSink.IsConfiguredForLevel(level);
            }

            // Default to true if the sink does not implement ISinkConfigurable
            return true;
        }
    }
}
    
