using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Factories;

public interface IBotFactory
{
    List<Bot> GetBots();
}