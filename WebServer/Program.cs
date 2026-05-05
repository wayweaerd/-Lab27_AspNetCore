var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.Use(async (context, next) => {
//     Console.WriteLine($"[LOG]{context.Request.Method}{context.Request.Path}");
//     await next(context);
//     Console.WriteLine($"[LOG] ответ отправлен: {context.Response.StatusCode}");
// });

// app.Use(async (context, next) =>
// {
//     context.Response.Headers.Append("X-Powered-By", "ASP.Net Core Lab27");
//     await next(context);
// });

// // app.MapGet("/", () => "Привет от Исп-235!,автор: Боровой Роман,Соколов Владимер");
// app.MapGet("/", () => "Добро пожаловать на сервер!");

// app.MapGet("/about", () => "Это мой первый ASP.NET Core сервак");

// app.MapGet("/time", () => $"Время на сервере: {DateTime.Now}");

// app.MapGet("/hello/{name}", (string name) => $"привет,{name}!");

// app.MapGet("/sum/{a}/{b}", (double a, double b) => $"сумма:{a + b}");

// app.MapGet("/student", () => new
// {
//     Name = "Боровой Владимер",
//     Group = "ИСП-235",
//     Year = 3,
//     IsActive = true
// });
// app.MapGet("/subjects", () => new[] {
//     "РПМ",
//     "РМП",
//     "ИСРПО",
//     "СП",
// });
// app.MapGet("/product/{id}", (int id) => new Product(
//     Id: id,
//     Name: $"Товар #{id}",
//     Price: id * 99.99m,
//     InStock: id % 2 == 0
// ));

app.Use(async (context, next) => {
    var method = context.Request.Method;
    var path = context.Request.Path;
    Console.WriteLine($"->{method} {path}");
    await next(context);
});


app.MapGet("/", () => Results.Ok(new
{
    Message = "Добро пожаловать!",
    Version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")

}));

app.MapGet("/me", () => Results.Ok(new
{
    Name = "Боровой Роман",
    Group = "ИСП-234",
    Course = 3,
    Skils = new[] { "C#", "HTML", "CSS", "JS", "ASP.NET" }
}));
app.MapGet("/calc/{a}/{b}", (double a, double b) => Results.Ok(new
{
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
}));
app.MapFallback(() => Results.NotFound(new
{
    Error = "Маршрут не найден",
    code = 404
}));


app.Run();
// record Product(int Id, string Name, decimal Price, bool InStock);