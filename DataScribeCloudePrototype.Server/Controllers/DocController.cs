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
    public class DocController : ControllerBase
    {
        private readonly FileStorageManager _manager;
        private readonly ApplicationDbContext _context;
        public DocController(FileStorageManager fileStorageManager, ApplicationDbContext context)
        {
            _manager = fileStorageManager;
            _context = context;
        }

        [HttpGet("GetDocs")]
        public async Task<List<DocFiles>> GetDocs()
        {
            return await _context.DocFiles
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost("AddDocFiles")]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> AddDocFiles(IFormFile file)
        {
            if (file == null && file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            await _manager.AddFile(FileType.Doc, file);
            var doc = await _context.DocFiles.OrderByDescending(i => i.Id).FirstOrDefaultAsync();
            return Ok(doc);
        }

        [HttpDelete("DeleteDocFile")]
        public async Task<IActionResult> DeleteDocFile(int id)
        {
            await _manager.DeleteFile(FileType.Doc, id);
            return Ok("Removing was successful");
        }
    }
}
