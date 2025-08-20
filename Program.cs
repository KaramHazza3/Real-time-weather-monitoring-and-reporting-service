using FTSWeatherMonitoringAndReporting.Configuration;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Factories;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;
using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;
using FTSWeatherMonitoringAndReporting.Features.WeatherStation;
using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Providers;

namespace FTSWeatherMonitoringAndReporting;

class Program
{
    static void Main(string[] args)
    {
        var botConfigurations = ConfigurationReader<Dictionary<BotType, BotConfiguration>>.Read("appsettings.json");
        var strategyFactories = new List<IBotStrategyFactory>
        {
             new RainBotStrategyFactory(),
             new SunBotStrategyFactory(),
             new SnowBotStrategyFactory() 
        };
        var botFactory = new BotFactory(botConfigurations, strategyFactories);
        var activatedBots = botFactory.GetBots();
        var weatherStation = new WeatherStation(new ConsoleWeatherProvider());
        foreach (var bot in activatedBots)
        {
            weatherStation.WeatherCreated += bot.OnWeatherCreated!;
        }
        weatherStation.GetWeather();
    }
}