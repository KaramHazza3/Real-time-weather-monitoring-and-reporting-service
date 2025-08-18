using System.Text.Json;

namespace FTSWeatherMonitoringAndReporting;

public class JsonParser : IInputParser<Weather>
{
    public Weather Parse(string input)
    {
        try
        {
            var result = JsonSerializer.Deserialize<Weather>(input);

            if (result == null)
                throw new ParsingException("JSON", new NullReferenceException("Deserialized result was null"));

            return result;
        }
        catch (JsonException e)
        {
            throw new ParsingException("JSON", e);
        }
    }
}