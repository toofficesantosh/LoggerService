using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using System.Globalization;

namespace LoggerLibrary.Implementation
{
    // <summary>
    /// Represents a File sink for logging messages in the file.
    /// </summary>
    public class FileSink : ILogSink, ISinkConfigurable
    {
        private readonly string filePath;
        private readonly List<LogLevel> configuredLevels;        
        private static readonly object fileLockObject = new object();

        public FileSink(string filePath, List<LogLevel> configuredLevels)
        {
            this.filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            this.configuredLevels = configuredLevels ?? throw new ArgumentNullException(nameof(configuredLevels));

        }

        #region Methods
        /// <summary>
        /// Logs a message to the File.
        /// </summary>
        /// <param name="message">The log message to be logged.</param>
        public void LogMessage(LogMessage message)
        {
            lock (fileLockObject)
            {
                // Implementation to log message to a file
                System.IO.FileInfo logFile = new System.IO.FileInfo(filePath);
                logFile.Directory.Create(); // If the directory already exists, this method does nothing.

                // Implementation to log message to a file            
                File.AppendAllText(filePath, $"----------Log Entry at----------{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}----------\n" +
                                    $"{message.Level}: {message.Namespace} - {message.Content}\n----------");
            }

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
