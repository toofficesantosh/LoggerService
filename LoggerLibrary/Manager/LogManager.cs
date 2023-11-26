using LoggerLibrary.Implementation;
using LoggerLibrary.Interface;
using LoggerLibrary.Model;
using LoggerLibrary.Utility;
using System.Text.Json;

namespace LoggerLibrary.Manager
{
    /// <summary>
    /// Manages logging configurations and sink initialization.
    /// </summary>
    public class LogManager
    {

        #region Methods
        /// <summary>
        /// Reads the logging configurations from a JSON file.
        /// </summary>
        /// <param name="configFile">The path to the JSON configuration file.</param>
        /// <returns>The sink configurations read from the file.</returns>
        public static SinkConfigurations ReadConfiguration(string configFile)
        {
           
                // Read JSON configuration from file
                var jsonConfig = File.ReadAllText(configFile);

                // Deserialize JSON to LoggerConfiguration
                return JsonSerializer.Deserialize<SinkConfigurations>(jsonConfig);
            
        }

        /// <summary>
        /// Initializes a list of log sinks based on the provided configurations.
        /// </summary>
        /// <param name="configuration">The sink configurations.</param>
        /// <returns>A list of initialized log sinks.</returns>
        public static List<ILogSink> InitializeSinks(SinkConfigurations configuration)
        {
            var sinks = new List<ILogSink>();

            // Iterate through each sink configuration and create the corresponding sink instance
            foreach (var sinkConfig in configuration.SinkConfigs)
            {
                var sink = CreateSinkFromConfiguration(sinkConfig);
                sinks.Add(sink);
            }

            return sinks;
        }

        /// <summary>
        /// Creates log sinks instance based on the provided sink configuration.
        /// </summary>
        /// <param name="sinkConfig">The sink configuration.</param>
        /// <returns>And initialized log sink instance.</returns>
        public static ILogSink CreateSinkFromConfiguration(SinkConfiguration sinkConfig)
        {
            // Convert string representations of levels to LogLevel enum
            List<LogLevel> levels = UtilityManager.ConvertToEnumList<LogLevel>(sinkConfig.Levels);

            // Get the log type from the configuration
            LogType type = UtilityManager.GetLogType(sinkConfig.Type);

            // Determine sink type and create an instance based on the configuration
            switch (type)
            {
                case LogType.File:
                    return new FileSink(sinkConfig.FilePath, levels);
                case LogType.Console:
                    return new ConsoleSink(levels);
                case LogType.Database:
                    return new DatabaseSink(sinkConfig.DBConnection, levels);
                default:
                    throw new InvalidOperationException($"Unsupported sink type: {sinkConfig.Type}");
            }
        }
        #endregion
    }
}
