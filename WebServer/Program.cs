var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Привет от Исп-235!,автор: Боровой Роман,Соколов Владимер");
app.MapGet("/", () => "Добро пожаловать на сервер!");

app.MapGet("/about", () => "Это мой первый ASP.NET Core сервак");

app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"привет,{name}!");

app.MapGet("/sum/{a}/{b}", (double a, double b) => $"сумма:{a+b}");
app.Run();
