using FTSWeatherMonitoringAndReporting.Common.Parsers;
using FTSWeatherMonitoringAndReporting.Common.Parsers.Helpers;
using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherStation.Providers;

public class ConsoleWeatherProvider : IWeatherProvider
{
    public Weather? GetWeather()
    {
        Console.Write("Enter weather data (JSON or XML): ");
        var weatherData = Console.ReadLine();
        if (weatherData == null)
        {
            Console.WriteLine("Invalid input");
            return null;
        }
        var parser = ParserHelper.GetParser<Weather>(weatherData);
        if (parser != null) return parser.Parse(weatherData);
        Console.WriteLine("Invalid input");
        return null;
    }
}