using Dal;
using Dal.Extensions;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;
using System.Configuration;

var connString = "Server=localhost;Port=3307;Database=nuvem_db;Uid=root;Pwd=P4$$abcd;";
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddDalServices();
builder.Services.AddPharmacyServices();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
