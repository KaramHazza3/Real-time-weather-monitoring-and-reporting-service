using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherStation.Providers;

public interface IWeatherProvider
{
    Weather? GetWeather();
}