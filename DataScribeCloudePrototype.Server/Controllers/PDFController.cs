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
    public class PdfController : ControllerBase
    {
        private readonly FileStorageManager _manager;
        private readonly ApplicationDbContext _context;
        public PdfController(FileStorageManager fileStorageManager, ApplicationDbContext context)
        {
            _manager = fileStorageManager;
            _context = context;
        }

        [HttpGet("GetPDFs")]
        public async Task<List<Pdf>> GetPDFs()
        {
            return await _context.Pdf
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost("AddPDF")]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> AddPdfFiles(IFormFile file)
        {
            if (file == null && file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            await _manager.AddFile(FileType.PDF, file);
            var pdf = await _context.Pdf.OrderByDescending(i => i.PDFId).FirstOrDefaultAsync();
            return Ok(pdf);
        }

        [HttpDelete("DeletePDFFile")]
        public async Task<IActionResult> DeletePdfFile(int id)
        {
            await _manager.DeleteFile(FileType.PDF, id);
            return Ok("Removing was successful");
        }
    }
}
