using BitStore.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BitStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _objectService;

        public ItemController(ILogger<ItemController> logger, IItemService objectService)
        {
            _logger = logger;
            _objectService = objectService;
        }

        [SwaggerOperation(Summary = "Gets file from storage by identifier")]
        [HttpGet("{id}")]
        public async Task<FileStreamResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var stream = await _objectService.GetItem(id, cancellationToken);

            return File(stream, "application/octet-stream");
        }

        [SwaggerOperation(Summary = "Adds file to storage")]
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile formFile, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding new file {FileName}", formFile.FileName);
            await _objectService.AddItem(formFile, cancellationToken);
            return Ok();
        }

        [SwaggerOperation(Summary = "Updates file in storage by identifier")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, IFormFile formFile, CancellationToken cancellationToken)
        {
            await _objectService.UpdateItem(id, formFile, cancellationToken);
            return Ok();
        }
    }
}