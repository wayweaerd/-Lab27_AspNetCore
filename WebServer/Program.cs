var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Привет от Исп-235!,автор: Боровой Роман,Соколов Владимер");
app.MapGet("/", () => "Добро пожаловать на сервер!");

app.MapGet("/about", () => "Это мой первый ASP.NET Core сервак");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"привет,{name}!");

app.MapGet("/sum/{a}/{b}", (double a, double b) => $"сумма:{a + b}");

app.MapGet("/student", () => new
{
    Name = "Боровой Владимер",
    Group = "ИСП-235",
    Year = 3,
    IsActive = true
});
app.MapGet("/subjects", () => new[] {
    "РПМ",
    "РМП",
    "ИСРПО",
    "СП",
});
app.MapGet("/product/{id}", (int id) => new Product(
    Id: id,
    Name: $"Товар #{id}",
    Price: id * 99.99m,
    InStock: id % 2 == 0
));
app.Run();
record Product(int Id, string Name, decimal Price, bool InStock);