using FTSWeatherMonitoringAndReporting.Features.WeatherBots.Strategies;
using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Events;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherBots.Models;

public class Bot
{
    private readonly BotStrategy _botStrategy;
    public Bot(BotStrategy botStrategy)
    {
        _botStrategy = botStrategy;
    }
        
    public void OnWeatherCreated(object sender, WeatherCreatedEventArgs e)
    {
        if (!_botStrategy.ShouldActivate(e.Weather)) return;
        _botStrategy.SendMessage();
    }
}