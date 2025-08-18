namespace FTSWeatherMonitoringAndReporting;

public class ParsingException : Exception
{
    public ParsingException(string format, Exception inner) 
        : base($"Failed to parse {format} input", inner) {}
}