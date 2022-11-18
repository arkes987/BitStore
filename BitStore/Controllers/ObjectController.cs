using Microsoft.AspNetCore.Mvc;

namespace BitStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjectController : ControllerBase
    {
        private readonly ILogger<ObjectController> _logger;

        public ObjectController(ILogger<ObjectController> logger)
        {
            _logger = logger;
        }

        //GET FILE

        //UPLOAD FILE

        //UPDATE FILE

        //GET METADATA

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}