using System.Runtime.CompilerServices;
using HW_16.Models;
using HW_16.Repositories;

//ShowCustomers();
//ShowProducts();
//ShowOrders();
//ShowCustomersUnderAge(30);
//ShowOrdersById(2);
//ShowLastOrder();
//AddProduct ("test", "this id test product to add", -1000);
//ShowProductById(23);

void ShowCustomers()
{
    Console.WriteLine($"Customers");
    for (var i = 0; i < 2; i++)
    {
        Console.WriteLine($"page: {i + 1}");
        var customers = CustomerRepository.GetCustomers(i);
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Id}: {customer.FirstName} \t {customer.LastName} \t {customer.Age}");
        }
    }
}

void ShowProducts()
{
    Console.WriteLine($"Products");
    for (var i = 0; i < 2; i++)
    {
        Console.WriteLine($"page: {i + 1}");
        var products = ProductRepository.GetProducts(i);
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}: {product.Name} \t {product.StockQuantity} \t {product.Price}");
        }
    }
}

void ShowOrders()
{
    Console.WriteLine("Orders");
    for (var i = 0; i < 5; i++)
    {
        Console.WriteLine($"page: {i + 1}");
        var orders = OrderRepository.GetOrders(i);
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.Id}: {order.CustomerId} \t {order.ProductId} \t {order.Quantity}");
        }
    }
}

void ShowCustomersUnderAge(int age)
{
    var customers = CustomerRepository.GetSortedCustomersUnderAge(age);
    foreach (var customer in customers)
    {
        Console.WriteLine($"{customer.Id}: {customer.FirstName} \t {customer.LastName} \t {customer.Age}");
    }
}

void ShowOrdersById(int id)
{
    var order = OrderRepository.GetOrdersByCustomerId(id);
    Console.WriteLine($"{order.Id}: {order.CustomerId} \t {order.ProductId} \t {order.Quantity}");
}

void AddProduct(string name, string description, int price)
{
    var productToAdd = new Product {Name = name, Description = description, Price = price };
    ProductRepository.AddProduct(productToAdd);
}

void ShowProductById(int id)
{
    var product = ProductRepository.GetProductById(id);
    Console.WriteLine($"{product.Id}: {product.Name} \t {product.StockQuantity} \t {product.Price}");
}

void ShowLastOrder()
{
    var order = OrderRepository.GetLastOrder();
    Console.WriteLine($"{order.Id}: {order.CustomerId} \t {order.ProductId} \t {order.Quantity}");
}