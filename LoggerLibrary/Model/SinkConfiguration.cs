namespace LoggerLibrary.Model
{
    /// <summary>
    /// This model is for the Sink Configuration details
    /// </summary>
    public class SinkConfiguration
    {
        public string Type { get; set; }
        public string FilePath { get; set; }
        public string DBConnection { get; set; }
        public List<string> Levels { get; set; }
    }

}
