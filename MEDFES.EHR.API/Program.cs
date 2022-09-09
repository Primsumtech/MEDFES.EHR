using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Infrastructure.DataBaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.File("errorlog.txt"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddInfrastructure();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MEDFES.EHR API's"));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
