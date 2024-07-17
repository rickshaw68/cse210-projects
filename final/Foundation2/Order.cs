using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) //adding product
    {
        _products.Add(product);
    }

    public double ProductCost()  //product cost
    {
        double totalProductCost = 0;
        foreach (var product in _products)
        {
            totalProductCost += product.TotalCost;
        }
        return totalProductCost;
    }

    public double ShippingCost()
    {
        return _customer.LivesInUSA() ? 5 : 35; // determines my shipping cost for USA or INternational (USA) : (INT)
    }

    public double TotalCost()
    {
        return ProductCost() + ShippingCost();
    }

    public string PackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var product in _products)
        {
            sb.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }
        return sb.ToString();
    }

    public string ShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.FullAddress()}";
    }
}
