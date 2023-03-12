
using RabbitMqAPI.RabitMQ;
using Prometheus;
using Microsoft.Extensions.Options;
using RabbitMqAPI.Controllers;

Metrics.SuppressDefaultMetrics();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRabbitMQProducer, RabitMQProducer>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var metricServer = new KestrelMetricServer(port: 1234);
metricServer.Start();


builder.Services.AddHttpClient(ProductController.HttpClientName);
    //.UseHttpClientMetrics();
// A sample service that uses the above HTTP client.
//builder.Services.AddHostedService<SampleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseHttpMetrics();

app.UseAuthorization();
app.MapControllers();


app.Run();