using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service.Interfaces;
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

        public async Task<int> AddImageFiles(IFormFile file)
        {
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Image");
            var uniqueFileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            
            var image = new Images
            {
                UrlImage = uniqueFileName
            };
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image.ImageId;
        }

        public async Task<int> AddNotes(string title, string content)
        {
            var notes = new Notes
            {
                Title = title,
                Content = content,
            };
            await _context.Notes.AddAsync(notes);
            await _context.SaveChangesAsync();
            return notes.NotesId;
        }

        public async Task UpdateNotes(int id, string title, string content) 
        {
            await _context.Notes
                .Where(c => c.NotesId == id)
                .ExecuteUpdateAsync(s => 
                s.SetProperty(c => c.Title, title)
                .SetProperty(c => c.Content, content));
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

        public async Task DeleteImageFiles(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(f => f.ImageId == id);
            if (image != null)
            {
                var filePath = Path.Combine("Data", "Image", image.UrlImage);
                File.Delete(filePath);
            }

            await _context.Images
                .Where(r=> r.ImageId==id)
                .ExecuteDeleteAsync();
        }
        public async Task DeleteNotes(int id)
        {
            await _context.Notes
                .Where(r => r.NotesId == id)
                .ExecuteDeleteAsync();
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
