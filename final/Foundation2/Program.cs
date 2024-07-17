using System;

class Program
{
    static void Main(string[] args)
    {        
        Address address1 = new Address("1428 Elm Street", "Springwood", "OH", "USA");  //customer addresses
        Address address2 = new Address("121 Mill Neck", "Long Island", "NY", "Canada"); // I know this is USA but I set the country to Canada to show the shipping costs are different for international addresses
        
        Customer customer1 = new Customer("Freddy Krueger", address1);  // my customers
        Customer customer2 = new Customer("John Wick", address2);
        
        Product product1 = new Product("Knife", "Butcher", 25.0, 3);  //Creating product information
        Product product2 = new Product("Stabby Thing", "STBY", 12.50, 1);
        Product product3 = new Product("Glock 34", "GL34", 250, 1);
        Product product4 = new Product("Heckler & Koch P30L", "P30", 300, 2);
        
        Order order1 = new Order(customer1); // setting up my order instances
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        
        DisplayOrderDetails(order1, "Order 1"); //display my orders
        DisplayOrderDetails(order2, "Order 2");
    }

    static void DisplayOrderDetails(Order order, string orderTitle)
    {
        Console.WriteLine($"{orderTitle}:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Product Cost: ${order.ProductCost():0.00}");
        Console.WriteLine($"Shipping Cost: ${order.ShippingCost():0.00}");
        Console.WriteLine($"Total Cost: ${order.TotalCost():0.00}");
        Console.WriteLine();
    }
}
