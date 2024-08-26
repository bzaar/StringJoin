var sales = new[] {
    new Sale(100, new Customer(1, "Bob")),
    new Sale(200, new Customer(2, "Jane")),
};

string topCustomers = string.Join(", ", 
    sales
        .GroupBy(s => s.Customer.Id)
        .OrderByDescending(g => g.Sum(sale => sale.Amount))
        .Take(3)
        .Select(g => g.First().Customer));

Console.WriteLine(topCustomers);

class Customer(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}

record Sale(decimal Amount, Customer Customer);
