using System.Collections.Generic;

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

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";

        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    public double GetTotalPrice()
    {
        double total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35;
        total += shipping;

        return total;
    }
}
