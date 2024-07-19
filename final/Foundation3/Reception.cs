public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address) //Getting info from the Event class
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
    }

    public override string ShortDescription()
    {
        return $"Type: Reception\nTitle: {Title}\nDate: {Date}";
    }
}
