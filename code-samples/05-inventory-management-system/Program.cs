var item = new StockItem("SKU-001", "Notebook", 10);
item.Restock(5);
item.Sell(12);
Console.WriteLine($"{item.Name}: {item.Stock} left");
public class StockItem(string sku, string name, int initialStock)
{
    public string Sku { get; } = !string.IsNullOrWhiteSpace(sku)
        ? sku : throw new ArgumentException("SKU required");
    public string Name { get; } = name;
    public int Stock { get; private set; } = initialStock >= 0
        ? initialStock : throw new ArgumentOutOfRangeException(nameof(initialStock));
    public void Restock(int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        Stock += qty;
    }
    public void Sell(int qty)
    {
        if (qty <= 0 || qty > Stock) throw new InvalidOperationException("Invalid sale");
        Stock -= qty;
    }
}
