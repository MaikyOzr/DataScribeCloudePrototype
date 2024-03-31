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

        public async Task<int> AddDocFiles(IFormFile file)
        {
            var userId = new User().Id;
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Doc");
            var uniqueFileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var doc = new DocFiles
            {
                DocUrl = uniqueFileName,
                CurrUserID = userId
            };
            await _context.DocFiles.AddAsync(doc);
            await _context.SaveChangesAsync();
            return doc.DocId;
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
            var userId = new User().Id;
            var notes = new Notes
            {
                CurrUserID = userId,
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

        public async Task<int> AddPDFFiles(IFormFile file)
        {
            var userId = new User().Id;
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PDF");
            var uniqueFileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var pdf = new Pdf
            {
                PDFUrl = uniqueFileName,
                CurrUserID = userId
            };
            await _context.Pdf.AddAsync(pdf);
            await _context.SaveChangesAsync();
            return pdf.PDFId;
        }

        public void DeleteAudioFiles(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDocFile(int id)
        {
            var doc = await _context.DocFiles.FirstOrDefaultAsync(f => f.DocId == id);
            if (doc != null)
            {
                var filePath = Path.Combine("Data", "Doc", doc.DocUrl);
                File.Delete(filePath);
            }

            await _context.DocFiles
                .Where(r => r.DocId == id)
                .ExecuteDeleteAsync();
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
                .Where(r => r.ImageId == id)
                .ExecuteDeleteAsync();
        }
        public async Task DeleteNotes(int id)
        {
            await _context.Notes
                .Where(r => r.NotesId == id)
                .ExecuteDeleteAsync();
        }

        public async Task DeletePDFFiles(int id)
        {
            var pdf = await _context.Pdf.FirstOrDefaultAsync(f => f.PDFId == id);
            if (pdf != null)
            {
                var filePath = Path.Combine("Data", "PDF", pdf.PDFUrl);
                File.Delete(filePath);
            }

            await _context.Pdf
                .Where(r => r.PDFId == id)
                .ExecuteDeleteAsync();
        }
    }
}
