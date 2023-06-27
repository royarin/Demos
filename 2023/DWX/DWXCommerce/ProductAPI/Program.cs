using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.GraphQL.SchemaTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<ProductContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("ProductContext"),
                options => options.EnableRetryOnFailure()));

builder.Services.AddGraphQLServer()
.RegisterDbContext<ProductContext>(DbContextKind.Pooled)
.AddQueryType<QueryType>();

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
