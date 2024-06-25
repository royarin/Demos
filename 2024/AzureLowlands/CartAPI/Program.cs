using CartAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddServiceProfiler();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register RedisConnection as a singleton and read connection string from appsettings.json
builder.Services.AddSingleton(new RedisConnection(builder.Configuration["Redis:ConnectionString"]));

// register cart service as a singleton
builder.Services.AddSingleton<ICartService, CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
