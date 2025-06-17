using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default") ?? "Data Source=App.db";

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
});


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGrpcService<SupplierService>();

app.Run();
