namespace FTSWeatherMonitoringAndReporting;

public interface IInputParser<TEntity> where TEntity : class
{
    TEntity Parse(string input);
}