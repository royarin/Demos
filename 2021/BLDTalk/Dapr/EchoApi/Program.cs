var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext httpContext) => $"Hello {httpContext.Request.Query["name"].ToString()}");

app.Run();
