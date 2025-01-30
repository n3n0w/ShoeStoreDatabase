using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ShoeStore.Infrastructure;
using ShoeStore.Infrastructure.Repositories;
using ShoeStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddSingleton<MongoDbContext>(sp =>
    new MongoDbContext(
        builder.Configuration.GetConnectionString("MongoDB"),
        builder.Configuration["DatabaseName"]
    ));

builder.Services.AddScoped<ShoeRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<ShoeService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<BusinessService>();

builder.Services.AddControllers();

// Add health checks
builder.Services.AddHealthChecks()
    .AddCheck("ShoeStoreHealthCheck", () => Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHealthChecks("/health");

app.Run();