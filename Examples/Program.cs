var sales = new[] {
    new {Amount = 100, Customer = new {Id = 1, Name = "Bob"}},
    new {Amount = 200, Customer = new {Id = 2, Name = "Jane"}},
    new {Amount = 150, Customer = new {Id = 3, Name = "Alice"}},
};

string top3Customers = string.Join(", ", sales
        .GroupBy(s => s.Customer.Id)
        .OrderByDescending(g => g.Sum(sale => sale.Amount))
        .Take(3));

Console.WriteLine(top3Customers);
