using FTSWeatherMonitoringAndReporting.Configuration;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public class RainBotStrategyFactory : IBotStrategyFactory
{
    public BotType BotType => BotType.RainBot;
    public BotStrategy? Create(BotConfiguration botConfiguration)
    {
        if (!botConfiguration.Enabled) return null;
        return new RainBotStrategy(nameof(BotType.RainBot), botConfiguration.Message,
            botConfiguration.HumidityThreshold);
    }
}