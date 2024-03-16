using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Service
{
    public class FileStorageManager : IFileStorage
    {

        private readonly ApplicationDbContext _context;

        public FileStorageManager(ApplicationDbContext context)
        {
            _context = context;

        }

        public Task<IActionResult> DeleteAudioFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDocFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteImageFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteNotes(Notes notes)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeletePDFFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SaveAudioFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SaveDocFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SaveImageFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void SaveNotes(Notes notes)
        {
            _context.Notes.Add(notes);
            _context.SaveChangesAsync();
        }

        public Task<IActionResult> SavePDFFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
