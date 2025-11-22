namespace OnlineOrdering;
class Program
{
    static void Main(string[] args)
    {
        // ===== ORDER 1 =====
        Address address1 = new Address("1234 Elm St", "Anton", "CA 12345", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Product 1", "1", 10, 1));
        order1.AddProduct(new Product("Product 2", "2", 7, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        // ===== ORDER 2 =====
        Address address2 = new Address("5678 Oak St", "Smectic", "XY 67890", "Nigeria");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Product A", "4", 15, 1));
        order2.AddProduct(new Product("Product B", "5", 5, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}\n");
    }
}