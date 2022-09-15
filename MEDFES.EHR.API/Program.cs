using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Infrastructure.DataBaseContext;
using Application.UseCases.Authentication;
using Application.UseCases.User;
using Application.Repositories;
using Infrastructure.Repository.Authentication;
using Infrastructure.Repository.User;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthenticationUsecase, AuthenticationUsecase>();
builder.Services.AddScoped<IUserUsecase, UserUsecase>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
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
