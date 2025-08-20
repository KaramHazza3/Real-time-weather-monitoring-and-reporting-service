using FTSWeatherMonitoringAndReporting.Configuration;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public class SunBotStrategyFactory : IBotStrategyFactory
{
    public BotType BotType => BotType.SunBot;
    public BotStrategy? Create(BotConfiguration botConfiguration)
    {
        if (!botConfiguration.Enabled) return null;
        return new SunBotStrategy(nameof(BotType.SunBot), botConfiguration.Message,
            botConfiguration.TemperatureThreshold);
    }
}