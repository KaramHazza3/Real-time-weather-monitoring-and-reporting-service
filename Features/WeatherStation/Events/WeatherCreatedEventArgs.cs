using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherStation.Events;

public class WeatherCreatedEventArgs : EventArgs
{
    public Weather Weather { get; }
    public WeatherCreatedEventArgs(Weather weather) => Weather = weather;
}