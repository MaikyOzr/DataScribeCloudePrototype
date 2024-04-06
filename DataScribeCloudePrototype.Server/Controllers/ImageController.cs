using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Repositories.Enums;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default30")]
    public class ImageController : ControllerBase
    {
        private readonly FileStorageManager _manager;
        private readonly ApplicationDbContext _context;
        public ImageController(FileStorageManager fileStorageManager, ApplicationDbContext context)
        {
            _manager = fileStorageManager;
            _context = context;
        }

        [HttpGet("GetImages")]
        public async Task<List<Images>> GetImages() {
            return await _context.Images
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost("AddImage")]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> AddImage(IFormFile file)
        {
            if (file == null && file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            await _manager.AddFile(FileType.Image, file);
            var image = await _context.Images.OrderByDescending(i => i.ImageId).FirstOrDefaultAsync();
            return Ok(image);
        }

        [HttpDelete("DeleteImageFile")]
        public async Task<IActionResult> DeleteImageFile(int id) 
        {
            await _manager.DeleteFile(FileType.Image, id);
            return Ok("Removing was successful");
        }
    }
}
