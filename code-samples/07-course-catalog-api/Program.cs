var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var courses = new Dictionary<int, Course>
{
    [1] = new(1, "C# Fundamentals", 8),
    [2] = new(2, "ASP.NET Core", 12)
};
app.MapGet("/courses", () => Results.Ok(courses.Values));
app.MapGet("/courses/{id:int}", (int id) =>
    courses.TryGetValue(id, out var course) ? Results.Ok(course) : Results.NotFound());
app.MapPost("/courses", (CreateCourse request) =>
{
    if (string.IsNullOrWhiteSpace(request.Title) || request.Weeks <= 0)
        return Results.BadRequest(new { error = "Valid title and weeks required" });
    int id = courses.Keys.DefaultIfEmpty(0).Max() + 1;
    var course = new Course(id, request.Title, request.Weeks);
    courses.Add(id, course);
    return Results.Created($"/courses/{id}", course);
});
app.Run();
record Course(int Id, string Title, int Weeks);
record CreateCourse(string Title, int Weeks);
