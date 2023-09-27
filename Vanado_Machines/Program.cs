using Dapper;
using System.Data.SqlClient;
using Vanado_Machines.Context;
using Vanado_Machines.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

       
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<DapperContext, DapperContext>();

        builder.Services.AddScoped<IDbService, DbService>();
        builder.Services.AddScoped<IMachineService, MachineService>();
        builder.Services.AddScoped<IFailureService, FailureService>();

        builder.Services.AddControllers();

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
    }
}