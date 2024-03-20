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

        public void AddAudioFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void AddDocFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void AddImageFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public async Task AddNotes(Notes notes)
        {
            await _context.Notes.AddAsync(notes);
            await _context.SaveChangesAsync();
        }

        public void AddPDFFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void DeleteAudioFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void DeleteImageFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotes(Notes notes)
        {
            throw new NotImplementedException();
        }

        public void DeletePDFFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void GetFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
