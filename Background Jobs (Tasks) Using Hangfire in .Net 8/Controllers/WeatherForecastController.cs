using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Background_Jobs__Tasks__Using_Hangfire_in_.Net_8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
          
          //  BackgroundJob.Enqueue(()=>sendMessage("sarah77nashat77@gamil.com"));

            Console.WriteLine(DateTime.Now);
           // BackgroundJob.Schedule(() => sendMessage("sarah77nashat77@gamil.com"),TimeSpan.FromMinutes(1));

            RecurringJob.AddOrUpdate(() => sendMessage("sarah77nashat77@gamil.com"),Cron.Minutely);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [ApiExplorerSettings(IgnoreApi =true)]
        public void sendMessage(string email)
        {
            Console.WriteLine($"Email is send{DateTime.Now}");
        }
    }
}
