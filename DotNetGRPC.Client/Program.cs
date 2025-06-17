using Common;
using DotNetGRPC.Common.Dtos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using var channel = GrpcChannel.ForAddress("https://localhost:7274");

app.MapPost("/CreateSupplier", async ([FromBody] CreateSupplierDto model) =>
{

    var client = new SupplierProto.SupplierProtoClient(channel);

    var reply = await client.CreateSupplierAsync(new CreateSupplierRequest
    {
        Name = model.Name
    });

    return reply;
}).WithParameterValidation();


app.MapGet("/ListSuppliers", async () =>
{
    var client = new SupplierProto.SupplierProtoClient(channel);
    return await client.GetAllAsync(new());
});

app.Run();
