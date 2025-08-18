namespace FTSWeatherMonitoringAndReporting;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(FindProjectPath())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var jsonParser = new JsonParser();
        var res = jsonParser.Parse("{\"Location\": \"City Name\", \"Temperature\": 35, \"Humidity\": 40}");
        Console.WriteLine(res);
        var xmlParser = new XmlParser();
        var res1 = xmlParser.Parse("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>");
        Console.WriteLine(res1);

        Console.WriteLine(config["Rainbot:humidityThreshold"]);
    }
    private static string FindProjectPath()
    {
        var current = Directory.GetCurrentDirectory();
        while (current != null && !File.Exists(Path.Combine(current, "Program.cs")))
        {
            current = Directory.GetParent(current)?.FullName;
        }
        return current!;
    }
}