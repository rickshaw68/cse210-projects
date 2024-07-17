public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string Name => _name; // I did this read only variable to keep the private string _name as private.  I guess I could have set it to 'protected' but the assignment said to make it private
    public Address Address => _address;

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}
