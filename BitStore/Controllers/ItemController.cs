using BitStore.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public async Task<FileStreamResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var stream = await _objectService.GetFile(id, cancellationToken);

            return File(stream, "application/octet-stream");
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile formFile, CancellationToken cancellationToken)
        {
            await _objectService.AddFile(formFile, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, IFormFile formFile, CancellationToken cancellationToken)
        {
            await _objectService.UpdateFile(id, formFile, cancellationToken);
            return Ok();
        }
    }
}