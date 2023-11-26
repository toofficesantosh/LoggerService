using LoggerLibrary.Model;

namespace LoggerLibrary.Interface
{
    // It is for the Sink that can be configured for specific log levels
    public interface ISinkConfigurable
    {
        /// <summary>
        /// Checks if the sink is configured to log messages for the specified log level.
        /// </summary>
        /// <param name="level">The log level to check configuration for.</param>
        /// <returns>True if the sink is configured for the specified level; otherwise, false.
        bool IsConfiguredForLevel(LogLevel level);
    }
}
