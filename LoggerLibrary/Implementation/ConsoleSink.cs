using LoggerLibrary.Interface;
using LoggerLibrary.Model;

namespace LoggerLibrary.Implementation
{

    /// <summary>
    /// Represents a console sink for logging messages in the Console.
    /// </summary>
    public class ConsoleSink : ILogSink, ISinkConfigurable
    {
        private readonly List<LogLevel> configuredLevels;

        /// <summary>
        /// Initializes a new instance of the class with configured log levels.
        /// </summary>
        /// <param name="configuredLevels">The list of log levels configured for this sink.</param>
        public ConsoleSink(List<LogLevel> configuredLevels)
        {
            this.configuredLevels = configuredLevels ?? throw new ArgumentNullException(nameof(configuredLevels));
        }

        #region Methods
        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="message">The log message to be logged.</param>
        public void LogMessage(LogMessage message)
        {
            // Implementation to log message to the console
            Console.WriteLine($"{message.Level}: {message.Content} and Namespace is {message.Namespace}");
        }

        /// <summary>
        /// Checks if the sink is configured to log messages for the specified log level.
        /// </summary>
        /// <param name="level">The log level to check configuration for.</param>
        /// <returns>True if the sink is configured for the specified level; otherwise, false.</returns>
        public bool IsConfiguredForLevel(LogLevel level)
        {
            // Check if the sink is configured for the specified level
            return configuredLevels.Contains(level);
        }
        #endregion
    }

}
