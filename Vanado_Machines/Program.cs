using Dapper;
using System.Data.SqlClient;
using Vanado_Machines.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();

DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IFailureService, FailureService>();