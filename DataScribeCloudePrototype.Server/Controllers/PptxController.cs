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
    public class PptxController : ControllerBase
    {
        private readonly FileStorageManager _manager;
        private readonly ApplicationDbContext _context;
        public PptxController(FileStorageManager fileStorageManager, ApplicationDbContext context)
        {
            _manager = fileStorageManager;
            _context = context;
        }

        [HttpGet("GetPptx")]
        public async Task<List<Pptx>> GetPptxs()
        {
            return await _context.Pptx
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost("AddPptxFiles")]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> AddPptxFiles(IFormFile file)
        {
            if (file == null && file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            await _manager.AddFile(FileType.Pptx, file);
            var doc = await _context.Pptx.OrderByDescending(i => i.Id).FirstOrDefaultAsync();
            return Ok(doc);
        }

        [HttpDelete("DeletePptxFile")]
        public async Task<IActionResult> DeletePptxFile(int id)
        {
            await _manager.DeleteFile(FileType.Pptx, id);
            return Ok("Removing was successful");
        }
    }
}
