using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first order
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A101", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "B202", 25.50, 2));

        // Create second order
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Mary Johnson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "C303", 180.00, 1));
        order2.AddProduct(new Product("Keyboard", "D404", 45.00, 1));

        // Display order 1 details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}\n");

        // Display order 2 details
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}\n");
    }
}
