using System;

class Program
{
    static void Main(string[] args)
    {
        // ----- FIRST ORDER -----
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Donut Box", "D100", 4.50, 3));
        order1.AddProduct(new Product("Duff Beer Pack", "B200", 12.99, 2));

        Console.WriteLine("==================================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine("==================================================\n");

        // ----- SECOND ORDER -----
        Address address2 = new Address("Av. Amazonas 1234", "Quito", "Pichincha", "Ecuador");
        Customer customer2 = new Customer("Edgar Tulcán", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Gafas Ópticas", "G300", 45.00, 1));
        order2.AddProduct(new Product("Estuche Premium", "E150", 12.00, 1));
        order2.AddProduct(new Product("Limpia Lentes", "L050", 3.00, 2));

        Console.WriteLine("==================================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalPrice():0.00}");
        Console.WriteLine("==================================================\n");

        Console.WriteLine("PROGRAM FINISHED.");
    }
}
