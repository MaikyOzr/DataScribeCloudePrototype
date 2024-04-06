using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default30")]
    public class NotesController : ControllerBase
    {
        private readonly FileStorageManager _manager;
        private readonly ApplicationDbContext _context;
        public NotesController(FileStorageManager fileStorageManager, ApplicationDbContext context)
        {
            _manager = fileStorageManager;
            _context = context;
        }

        [HttpGet("GetNotes")]
        public async Task<List<Notes>> GetNotes()
        {
            return await _context.Notes
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost("AddNotes")]
        public async Task<IActionResult> AddNotes(string title, string content)
        {
            int Id = await _manager.AddNotes(title, content); 
            var addedNote = await _context.Notes.FindAsync(Id); 
            return Ok(addedNote);
        }

        [HttpPut("UpdateNotes")]
        public async Task<IActionResult> UpdateNotes(int id, string title, string content)
        {
            await _manager.UpdateNotes(id, title, content);
            var updatedNotes = await _context.Notes.FindAsync(id);
            return Ok(updatedNotes);
        }

        [HttpDelete("DeleteNotes")]
        public async Task<IActionResult> DeleteNotes(int id) {
            await _manager.DeleteNotes(id);
            return Ok("Removing was seccessful");
        }

    }
}
