using FTSWeatherMonitoringAndReporting.Configuration;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Factories;

public class BotFactory : IBotFactory
{
    private readonly Dictionary<BotType, BotConfiguration> _botConfigurations;
    private readonly List<IBotStrategyFactory> _botStrategyFactories;
    public BotFactory(Dictionary<BotType, BotConfiguration> botConfigurations, List<IBotStrategyFactory> botStrategyFactories)
    {
        _botConfigurations = botConfigurations;
        _botStrategyFactories = botStrategyFactories;
    }
    public List<Bot> GetBots()
    {
        var bots = new List<Bot>();
        foreach (var botStrategyFactory in _botStrategyFactories)
        {
            if (!_botConfigurations.TryGetValue(botStrategyFactory.BotType, out var config)) continue;
            var botStrategy = botStrategyFactory.Create(config);
            if (botStrategy == null) continue;
            bots.Add(new Bot(botStrategy));
        }
        return bots;
    }
}