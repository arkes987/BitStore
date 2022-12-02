using BitStore.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BitStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolumeController : ControllerBase
    {
        private readonly ILogger<VolumeController> _logger;
        private readonly IVolumeService _volumeService;

        public VolumeController(ILogger<VolumeController> logger, IVolumeService volumeService)
        {
            _logger = logger;
            _volumeService = volumeService;
        }

        [SwaggerOperation(Summary = "Registers new volume for files")]
        [HttpPost]
        public async Task<IActionResult> RegisterVolume(string share)
        {
            _logger.LogInformation("Preparing to register new volume on path {share}", share);
            await _volumeService.RegisterVolume(share);

            return Ok();
        }

    }
}
