using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Repositories.Enums;
using DataScribeCloudePrototype.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Service
{
    public class FileStorageManager 
        : IAddFiles, IDeleteFiles, IDeleteNotes
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;
        private readonly FileFactory _fileFactory;
        public FileStorageManager(ApplicationDbContext context, UserManager userManager, FileFactory fileFactory)
        {
            _context = context;
            _userManager = userManager;
            _fileFactory = fileFactory;
        }

        public async Task<int> AddNotes(string title, string content)
        {
            var userId = _userManager.GetCurrUserId();
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
        
        public async Task DeleteNotes(int id)
        {
            await _context.Notes
                .Where(r => r.NotesId == id)
                .ExecuteDeleteAsync();
        }

        public async Task<int> AddFile(FileType fileType, IFormFile file) => 
            await _fileFactory.AddFile(fileType, file);
        
        

        public async Task DeleteFile(FileType fileType, int id)
        {
            string filePath;
            switch (fileType)
            {
                case FileType.Doc:
                    var doc = await _context.DocFiles.FirstOrDefaultAsync(f => f.Id == id);
                    if (doc == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Doc", doc.DocUrl);
                    File.Delete(filePath);
                    await _context.DocFiles
                        .Where(r => r.Id == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.Image:
                    var image = await _context.Images.FirstOrDefaultAsync(f => f.Id == id);
                    if (image == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Image", image.UrlImage);
                    File.Delete(filePath);
                    await _context.Images
                        .Where(r => r.Id == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.PDF:
                    var pdf = await _context.Pdf.FirstOrDefaultAsync(f => f.Id == id);
                    if (pdf == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PDF", pdf.PDFUrl);
                    File.Delete(filePath);
                    await _context.Pdf
                        .Where(r => r.Id == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.Audio:
                    var audio = await _context.Audio.FirstOrDefaultAsync(f => f.Id == id);
                    if (audio == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Audio", audio.UrlAidio);
                    File.Delete(filePath);
                    await _context.Audio
                        .Where(r => r.Id == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.Pptx:
                    var pptx = await _context.Pptx.FirstOrDefaultAsync(f => f.Id == id);
                    if (pptx == null)
                        return;
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pptx", pptx.PptxUrl);
                    File.Delete(filePath);
                    await _context.Pptx
                        .Where(r => r.Id == id)
                        .ExecuteDeleteAsync();
                    break;
                default:
                    throw new InvalidOperationException("Invalid file type");
            }
        }
    }
}
