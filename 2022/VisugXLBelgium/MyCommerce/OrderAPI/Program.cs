using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.GraphQL.SchemaTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<OrderContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("OrderContext"),
                options => options.EnableRetryOnFailure()));

builder.Services.AddGraphQLServer()
.RegisterDbContext<OrderContext>(DbContextKind.Pooled)
.AddQueryType<QueryType>()
.AddMutationType<MutationType>();

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
