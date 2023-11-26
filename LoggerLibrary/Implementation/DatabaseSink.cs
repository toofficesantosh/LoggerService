using LoggerLibrary.Interface;
using LoggerLibrary.Model;

namespace LoggerLibrary.Implementation
{
    /// <summary>
    /// Represents a database sink to save logging messages in the database .
    /// </summary>
    public class DatabaseSink : ILogSink, ISinkConfigurable
    {
        private readonly string connectionString;
        private readonly List<LogLevel> configuredLevels;

        /// <summary>
        /// Initializes a new instance of the class with configured log levels.
        /// </summary>
        /// <param name="connectionString">The connection string of the database</param>
        /// <param name="configuredLevels">The list of log levels configured for this sink.</param>
        public DatabaseSink(string connectionString, List<LogLevel> configuredLevels)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.configuredLevels = configuredLevels ?? throw new ArgumentNullException(nameof(configuredLevels));

        }

        #region Methods
        /// <summary>
        /// Save a message to the database.
        /// </summary>
        /// <param name="message">The log message to be saved.</param>
        public void LogMessage(LogMessage message)
        {
            // Implementation to Save log message to a database
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
