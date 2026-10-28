using System.Text.Json;
var file = Path.Combine(Environment.CurrentDirectory, "expenses.json");
List<Expense> expenses;
try
{
    expenses = File.Exists(file)
        ? JsonSerializer.Deserialize<List<Expense>>(File.ReadAllText(file)) ?? []
        : [];
}
catch (JsonException)
{
    Console.WriteLine("Expense file is invalid. Fix the JSON before continuing.");
    return;
}
expenses.Add(new Expense(DateOnly.FromDateTime(DateTime.Today), "Transport", 1_500m));
await File.WriteAllTextAsync(file, JsonSerializer.Serialize(expenses,
    new JsonSerializerOptions { WriteIndented = true }));
foreach (var group in expenses.GroupBy(e => e.Category))
    Console.WriteLine($"{group.Key}: {group.Sum(e => e.Amount):N2}");
public record Expense(DateOnly Date, string Category, decimal Amount);
