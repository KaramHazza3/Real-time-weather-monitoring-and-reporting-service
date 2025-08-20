namespace FTSWeatherMonitoringAndReporting.Common.Parsers.Helpers;

public static class ParserHelper
{
    public static IParser<T>? GetParser<T>(string input) where T : class
    {
        if (input.StartsWith('<'))
        {
            return new XmlParser<T>();
        }

        if (input.StartsWith('{'))
        {
            return new JsonParser<T>();
        }

        return null;
    }
}