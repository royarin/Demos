var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//use tye service discovery
builder.Services.AddHttpClient("Products", c => c.BaseAddress = new Uri(builder.Configuration.GetServiceUri("product-api"),"/graphql"));
builder.Services.AddHttpClient("Inventory", c => c.BaseAddress = new Uri(builder.Configuration.GetServiceUri("inventory-api"),"/graphql"));
builder.Services.AddHttpClient("Order", c => c.BaseAddress = new Uri(builder.Configuration.GetServiceUri("order-api"),"/graphql"));

// Alternatively can also use URLs
// builder.Services.AddHttpClient("Products", c => c.BaseAddress = new Uri("https://localhost:5010/graphql"));
// builder.Services.AddHttpClient("Inventory", c => c.BaseAddress = new Uri("https://localhost:5020/graphql"));
// builder.Services.AddHttpClient("Order", c => c.BaseAddress = new Uri("https://localhost:5030/graphql"));

builder.Services.AddGraphQLServer()
.AddRemoteSchema("Products")
.AddRemoteSchema("Inventory")
.AddRemoteSchema("Order")
.AddTypeExtensionsFromFile("./Stitching.graphql");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
