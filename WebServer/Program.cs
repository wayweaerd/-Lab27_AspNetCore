var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Привет от Исп-235!,автор: Боровой Роман");

app.Run();
