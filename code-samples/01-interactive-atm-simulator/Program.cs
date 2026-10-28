decimal balance = 25_000m;
List<string> history = new();
while (true)
{
    Console.Write("1 Balance | 2 Deposit | 3 Withdraw | 4 History | 0 Exit: ");
    string? option = Console.ReadLine();
    if (option == "0") break;
    if (option == "1") { Console.WriteLine($"Balance: {balance:N2}"); continue; }
    if (option == "4") { foreach (var item in history) Console.WriteLine(item); continue; }
    if (option is not ("2" or "3")) { Console.WriteLine("Unknown menu option"); continue; }
    Console.Write("Amount: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
    { Console.WriteLine("Enter a positive amount."); continue; }
    if (option == "3" && amount > balance)
    { Console.WriteLine("Insufficient funds."); continue; }
    balance += option == "2" ? amount : -amount;
    history.Add($"{(option == "2" ? "Deposit" : "Withdraw")}: {amount:N2}");
    Console.WriteLine($"New balance: {balance:N2}");
}
