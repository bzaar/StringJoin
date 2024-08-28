# StringJoin

This package provides an extension method called .Join() that joins multiple strings into one string.

## Why?

At this point you must be saying "Wait a minute, but we already have ```string.Join()```,
why do we need another method to do the same thing?"

The reasons are several.

### Reason #1: Type safety

Consider this:

```csharp
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
```

What do you think it'll print? For me it printed:

```
System.Linq.Grouping`2[System.Int32,<>f__AnonymousType0`2[System.Int32,<>f__AnonymousType1`2[System.Int32,System.String
]]], System.Linq.Grouping`2[System.Int32,<>f__AnonymousType0`2[System.Int32,<>f__AnonymousType1`2[System.Int32,System.
String]]], System.Linq.Grouping`2[System.Int32,<>f__AnonymousType0`2[System.Int32,<>f__AnonymousType1`2[System.Int32,
System.String]]]
```

Not what you expected? Been there.

Things is, ```string.Join``` takes an ```IEnumerable<object>``` and calls ```.ToString()``` on each object.

Such errors could be easily avoided if the method took an ```IEnumerable<string>```. Then you would catch the error at compile time.

### Reason #2: Readability

Let's fix the above code:

```csharp
string top3Customers = string.Join(", ", sales
        .GroupBy(s => s.Customer.Id)
        .OrderByDescending(g => g.Sum(sale => sale.Amount))
        .Take(3)
        .Select(gr => gr.First().Customer.Name));
```
Now, let's rewrite it using the .Join() method from this library:

```csharp
string top3Customers = sales
        .GroupBy(s => s.Customer.Id)
        .OrderByDescending(g => g.Sum(sale => sale.Amount))
        .Take(3)
        .Select(gr => gr.First().Customer.Name)
        .Join(", ");
```

To me this reads better because:

1. There's less parens nesting (()).
2. The Join() is chained like Select() and Take(), etc, giving the statement a slick, easy to parse look. 
3. All the formatting code is in one place: we Select customer Names and Join them using commas.


### Reason #3: Char delimiter

There's an overload with a ```char``` delimiter which I think is very nice to have.


## Summing up

Reason #1 above got me so many times that I finally decided to write my own extension method that would save me from those errors once and for all. In fact, I've been using this extension method for quite a while and got so used to it that I began to miss it in other projects. That's when I knew I had to make it into a Nuget package.

## See also

If you generate lots of strings, it may be not the best idea to join them into one huge string in memory.

You may want to convert your IEnumerable<string> to a Stream.

That's exactly what one of my other packages does: https://github.com/bzaar/EnumerableToStream.
