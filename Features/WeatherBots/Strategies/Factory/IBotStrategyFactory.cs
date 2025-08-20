using FTSWeatherMonitoringAndReporting.Configuration;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public interface IBotStrategyFactory
{
    public BotType BotType { get; }
    BotStrategy? Create(BotConfiguration botConfiguration);
}