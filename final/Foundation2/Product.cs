public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string Name => _name;  // I did this read only variable to keep the private string _name as private.  I guess I could have set it to 'protected' but the assignment said to make it private
    public string ProductId => _productId;
    public double Price => _price;
    public int Quantity => _quantity;

    public double TotalCost => _price * _quantity;
}
