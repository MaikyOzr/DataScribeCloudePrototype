using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileStorageManager manager;
        private readonly ApplicationDbContext _context;
        public FilesController(FileStorageManager fileStorageManager, ApplicationDbContext context)
        {
            manager = fileStorageManager;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Notes>> GetNotes()
        {
            return await _context.Notes
                .AsNoTracking()
                .ToListAsync();
        }


        [HttpPost]
        public async Task AddNotes(string title, string content) {
    
            var notes = new Notes {
                Title = title, 
                Content = content,
            };
        
            await manager.AddNotes(notes);
        }
    }
}
