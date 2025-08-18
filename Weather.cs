using System.Xml.Serialization;

namespace FTSWeatherMonitoringAndReporting;

[XmlRoot("WeatherData")]
public class Weather
{
    public string Location { get; set; }
    public int Temperature { get; set; }
    public int Humidity { get; set; }

    public override string ToString()
    {
        return $"Location: {Location}, Temperature: {Temperature}, Humidity: {Humidity}";
    }
}