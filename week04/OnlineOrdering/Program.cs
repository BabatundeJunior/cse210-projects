using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        
        // Create first order
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Los Angeles", "CA", "USA"));
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", 101, 999.99, 1));
        order1.AddProduct(new Product("Mouse", 102, 25.50, 2));

        // Create second order
        Customer customer2 = new Customer("Alice Smith", new Address("456 Elm St", "Toronto", "ON", "Canada"));
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", 103, 200.00, 1));
        order2.AddProduct(new Product("Keyboard", 104, 50.00, 1));
        order2.AddProduct(new Product("Headset", 105, 75.00, 1));

        // Display order details
        DisplayOrderDetails(order1);
        Console.WriteLine("----------------------------------------");
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine("\nTotal Price: $" + order.CalculateTotalPrice());
    }
}

class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{name}\n{address.GetFullAddress()}";
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += product.GetLabel() + "\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return customer.GetShippingLabel();
    }
}
