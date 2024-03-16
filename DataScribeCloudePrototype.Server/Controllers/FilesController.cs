using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        [HttpGet("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Notes>> GetNotes()
        {
            var notes = _context.Notes.ToList();
            return Ok(notes);
        }


        [HttpPost("save")]
        public IActionResult SaveNotes([FromBody] Notes notes) {
            if (notes != null)
            {
                manager.SaveNotes(notes);
            }
            return Ok(notes);
        }
    }
}
