public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public string StreetAddress => _streetAddress; //I did this read only variable to keep the private _**** variables as private.  I guess I could have set it to 'protected' but the assignment said to make it private
    public string City => _city;
    public string StateProvince => _stateProvince;
    public string Country => _country;

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string FullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}
