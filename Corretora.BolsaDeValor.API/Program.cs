using Corretora.BolsaDeValor.API.Configuration;
using Delivery.WebAPI.Configuration;
using Microsoft.AspNetCore.Builder;
using Prometheus;
using System.Reflection;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));


#region Configure Services

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddSwaggerConfiguration(new (
    "Teste", 
    "teste",
     $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

builder.Services.RegisterServices();



var app = builder.Build();
#endregion


// Use the prometheus middleware
app.UseMetricServer();
app.UseHttpMetrics();


#region Configure Pipeline

DbMigrationHelpers.EnsureSeedData(app).Wait();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

app.Run();


#endregion