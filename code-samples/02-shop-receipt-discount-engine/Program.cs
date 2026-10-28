var items = new List<(string Name, decimal Price, int Quantity)>
{
    ("Notebook", 1_500m, 2),
    ("Pen", 350m, 3),
    ("Backpack", 8_000m, 1)
};
foreach (var item in items)
    Console.WriteLine($"{item.Name}: {item.Price:N2} x {item.Quantity}");
if (items.Any(i => i.Price < 0 || i.Quantity <= 0))
    throw new InvalidOperationException("Invalid cart item.");
decimal subtotal = items.Sum(i => i.Price * i.Quantity);
decimal discount = subtotal >= 10_000m ? subtotal * 0.10m : 0m;
Console.WriteLine($"Subtotal: {subtotal:N2}");
Console.WriteLine($"Discount: {discount:N2}");
Console.WriteLine($"Total: {subtotal - discount:N2}");
