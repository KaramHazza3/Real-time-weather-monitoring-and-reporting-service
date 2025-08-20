using FTSWeatherMonitoringAndReporting.Common.Parsers.Exceptions;
using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Events;
using FTSWeatherMonitoringAndReporting.Features.WeatherStation.Providers;

namespace FTSWeatherMonitoringAndReporting.Features.WeatherStation;

public class WeatherStation
{
    private readonly IWeatherProvider _weatherProvider;

    public WeatherStation(IWeatherProvider weatherProvider)
    {
        _weatherProvider = weatherProvider;
    }
    public event EventHandler<WeatherCreatedEventArgs> WeatherCreated;

    public void GetWeather()
    {
        while (true)
        {
            try
            {
                var weatherData = _weatherProvider.GetWeather();
                if (weatherData == null)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                OnWeatherCreated(new WeatherCreatedEventArgs(weatherData));
            }
            catch (ParsingException e)
            {
                Console.WriteLine("Invalid input");
                return;
            }
        }
    }
    protected virtual void OnWeatherCreated(WeatherCreatedEventArgs e)
    {
        WeatherCreated?.Invoke(this, e);
    }
}