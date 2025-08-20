using FTSWeatherMonitoringAndReporting.Configuration;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public class SnowBotStrategyFactory : IBotStrategyFactory
{
    public BotType BotType => BotType.SnowBot;
    public BotStrategy? Create(BotConfiguration botConfiguration)
    {
        if (!botConfiguration.Enabled) return null;
        return new SnowBotStrategy(nameof(BotType.SnowBot), botConfiguration.Message,
            botConfiguration.TemperatureThreshold);
    }
}