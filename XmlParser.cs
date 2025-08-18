using System.Xml;
using System.Xml.Serialization;

namespace FTSWeatherMonitoringAndReporting;

public class XmlParser : IInputParser<Weather>
{
    public Weather Parse(string input)
    {
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(Weather));
            using var reader = new StringReader(input);
     
            var result = xmlSerializer.Deserialize(reader);
            if (result == null)
            {
                throw new ParsingException("XML", new NullReferenceException("Deserialized result was null"));
            }
            return (Weather)result;
        }
        catch (XmlException e)
        {
            throw new ParsingException("XML", e);
        }
    }
}