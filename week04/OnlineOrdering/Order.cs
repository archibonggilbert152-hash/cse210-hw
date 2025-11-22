namespace OnlineOrdering;
public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.LivesInUSA() ? 5 : 35; // Shipping cost
        return total;
    }

    public string GetPackingLabel()
    {
        string result = "Packing Label:\n";
        foreach (Product product in _products)
        {
            result += product.GetPackingInfo() + "\n";
        }
        return result;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetShippingAddress()}";
    }
}
