namespace FTSWeatherMonitoringAndReporting.Configuration;

public record BotConfiguration(bool Enabled, decimal TemperatureThreshold ,decimal HumidityThreshold, string Message);