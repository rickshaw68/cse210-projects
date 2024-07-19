public abstract class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    protected string Title => _title; //this is probably not necessary but I wanted to keep the variables private and giving read only access in these lines.
    protected string Description => _description;
    protected string Date => _date;
    protected string Time => _time;
    protected Address Address => _address;

    protected Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string StandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.FullAddress()}";
    }

    public abstract string FullDetails();
    public abstract string ShortDescription();
}
