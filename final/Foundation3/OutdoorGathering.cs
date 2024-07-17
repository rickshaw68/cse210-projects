public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {_weatherForecast}";
    }

    public override string ShortDescription()
    {
        return $"Type: Outdoor Gathering\nTitle: {Title}\nDate: {Date}";
    }
}
