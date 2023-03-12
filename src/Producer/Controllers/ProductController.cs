using Microsoft.AspNetCore.Mvc;
using Prometheus;
using RabbitMqAPI.Models;
using RabbitMqAPI.RabitMQ;
using System.IO;
using System.Net.Http;
using System.Threading.Channels;


namespace RabbitMqAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public const string HttpClientName = "SampleServiceHttpClient";
        private readonly IRabbitMQProducer _rabitMQProducer;
        private readonly IHttpClientFactory _httpClientFactory;

        private static IMetricFactory BackgroundServicesMetricFactory = Metrics.WithLabels(new Dictionary<string, string>
        {
          // Labels applied to all metrics created via this factory.
          { "category", "Producer_Controller" }
        });

        private static readonly Gauge DocumentImportsInProgress = BackgroundServicesMetricFactory
            .CreateGauge("myapp_document_imports_in_progress", "Number of Product posts in progress.");

        private static readonly Counter ProcessedJobCount = BackgroundServicesMetricFactory
            .CreateCounter("myapp_jobs_processed_total", "Number of product operations done.", labelNames: new[] { "method", "enviroment" });

        private static Histogram MessageTime = BackgroundServicesMetricFactory
            .CreateHistogram("product_message_time", "Histogram of send messages durations.");


        private static Histogram GoogleTime = BackgroundServicesMetricFactory
            .CreateHistogram("HTTP_Google_Call_seconds", "Histogram of Google call durations.");

        private static Histogram MicrosoftTime = BackgroundServicesMetricFactory
            .CreateHistogram("HTTP_Microsoft_Call_seconds", "Histogram of Microsoft call durations.");

        public ProductController(IRabbitMQProducer rabitMQProducer, IHttpClientFactory httpClientFactory)
        {
            _rabitMQProducer = rabitMQProducer;
            _httpClientFactory = httpClientFactory;
        }


        [HttpPost("Message/POST")]
        public Message SendMessages(Message message)
        {
            MessageTime.RemoveLabelled();
            var productData = message;

            var startTime = DateTime.UtcNow;
            Random r = new Random();
            int randomNumberForProccessDuration = r.Next(3, 20);

            using (MessageTime.NewTimer())
            using (DocumentImportsInProgress.TrackInProgress())
            {
                while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(randomNumberForProccessDuration))
                {
                    _rabitMQProducer.SendProductMessage(productData);
                    ProcessedJobCount.WithLabels("SendMessages", "Test").Inc();
                }
            }

            return productData;
        }


        [HttpPost("Service/POST")]
        public async Task<Message> GetMessageAsync(Message message)
        {
            var productData = message;
            var httpClient = _httpClientFactory.CreateClient(HttpClientName);

            GoogleTime.RemoveLabelled();
            MicrosoftTime.RemoveLabelled();

            const string googleUrl = "https://google.com";
            const string microsoftUrl = "https://microsoft.com";

            //GoogleTime.WithLabels("GetMessageAsync", "Test", "Google");
            //MicrosoftTime.WithLabels("GetMessageAsync", "Test", "Microsoft");

            var googleTask = Task.Run(async delegate
            {  
                using (GoogleTime.NewTimer())
                {
                    using var response = await httpClient.GetAsync(googleUrl);
                }
            });

            var microsoftTask = Task.Run(async delegate
            {
                using (MicrosoftTime.NewTimer())
                {
                    using var response = await httpClient.GetAsync(microsoftUrl);
                }
            });
            

            await Task.WhenAll(googleTask, microsoftTask);

            ProcessedJobCount.WithLabels("GetMessageAsync", "Test").Inc();

            return productData;
        }
    }
}