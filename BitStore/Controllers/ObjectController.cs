using BitStore.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjectController : ControllerBase
    {
        private readonly ILogger<ObjectController> _logger;
        private readonly IObjectService _objectService;

        public ObjectController(ILogger<ObjectController> logger, IObjectService objectService)
        {
            _logger = logger;
            _objectService = objectService;
        }

        [HttpGet("{id}")]
        public async Task<FileStreamResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var stream = await _objectService.GetFile(id, cancellationToken);

            return File(stream, "application/octet-stream");
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