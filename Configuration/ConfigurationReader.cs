using FTSWeatherMonitoringAndReporting.Common;
using FTSWeatherMonitoringAndReporting.Common.Parsers.Helpers;
using FTSWeatherMonitoringAndReporting.Configuration.Exceptions;

namespace FTSWeatherMonitoringAndReporting.Configuration;

public static class ConfigurationReader<T> where T : class
{
    public static T Read(string fileName)
    {
        var configurationPath = PathHelper.GetFullPath(fileName);
        var configuration = File.ReadAllText(configurationPath);
        var parser = ParserHelper.GetParser<T>(configuration);
        if (parser == null)
        {
            throw new NotSupportedConfigurationFileException();
        }
        return parser.Parse(configuration);
    }
    
}