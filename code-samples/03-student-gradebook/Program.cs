var grades = new Dictionary<string, List<int>>
{
    ["Ada"] = [70, 80, 90],
    ["Tobi"] = [45, 65, 75],
    ["Zara"] = [100, 95, 95]
};
foreach (var entry in grades.OrderByDescending(x => x.Value.Average()))
{
    if (entry.Value.Any(s => s is < 0 or > 100))
        throw new InvalidOperationException("Invalid score.");
    double average = entry.Value.Average();
    string grade = average >= 70 ? "A" : average >= 60 ? "B" : average >= 50 ? "C" : "F";
    Console.WriteLine($"{entry.Key,-10} {average,6:F1} {grade}");
}
