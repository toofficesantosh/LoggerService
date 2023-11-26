namespace LoggerLibrary.Model
{
    /// <summary>
    /// This is the model for the LogMessage
    /// It can also have the other properties like dateTime, createdBy etc
    /// </summary>
    public class LogMessage
    {        
        public LogLevel Level { get; set; }
        public string Namespace { get; set; }
        public string Content { get; set; }
    }
}