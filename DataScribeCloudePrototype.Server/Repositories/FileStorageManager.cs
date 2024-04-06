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
        public FileStorageManager(ApplicationDbContext context, UserManager userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<int> AddFile(FileType fileType, IFormFile file)
        {
            var userId = _userManager.GetCurrUserId();
            var filePath = await SaveFileAsync(fileType, file);

            switch (fileType)
            {
                case FileType.Doc:
                    var doc = new DocFiles { DocUrl = filePath, CurrUserID = userId };
                    await _context.DocFiles.AddAsync(doc);
                    await _context.SaveChangesAsync();
                    return doc.DocId;
                    break;
                case FileType.Image:
                    var image = new Images { UrlImage = filePath, CurrUserID = userId };
                    await _context.Images.AddAsync(image);
                    await _context.SaveChangesAsync();
                    return image.ImageId;
                    break;
                case FileType.PDF:
                    var pdf = new Pdf { PDFUrl = filePath, CurrUserID = userId };
                    await _context.Pdf.AddAsync(pdf);
                    await _context.SaveChangesAsync();
                    return pdf.PDFId;
                    break;
                case FileType.Audio:
                    var audio = new Audio { UrlAidio = filePath, CurrUserID = userId };
                    await _context.Audio.AddAsync(audio);
                    await _context.SaveChangesAsync();
                    return audio.AudioId;
                    break;
                case FileType.Pptx:
                    var pptx = new Pptx { PptxUrl = filePath, CurrUserID = userId };
                    await _context.Pptx.AddAsync(pptx);
                    await _context.SaveChangesAsync();
                    return pptx.PptxId;
                    break;
                default:
                    throw new InvalidOperationException("Invalid file type");
            }
        }

        private async Task<string> SaveFileAsync(FileType fileType, IFormFile file)
        {
            var userId = _userManager.GetCurrUserId();
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileType.ToString());
            var uniqueFileName = Path.GetRandomFileName();
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
        

        public async Task DeleteFile(FileType fileType, int id)
        {
            string filePath;
            switch (fileType)
            {
                case FileType.Doc:
                    var doc = await _context.DocFiles.FirstOrDefaultAsync(f => f.DocId == id);
                    if (doc == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Doc", doc.DocUrl);
                    File.Delete(filePath);
                    await _context.DocFiles
                        .Where(r => r.DocId == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.Image:
                    var image = await _context.Images.FirstOrDefaultAsync(f => f.ImageId == id);
                    if (image == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Image", image.UrlImage);
                    File.Delete(filePath);
                    await _context.Images
                        .Where(r => r.ImageId == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.PDF:
                    var pdf = await _context.Pdf.FirstOrDefaultAsync(f => f.PDFId == id);
                    if (pdf == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PDF", pdf.PDFUrl);
                    File.Delete(filePath);
                    await _context.Pdf
                        .Where(r => r.PDFId == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.Audio:
                    var audio = await _context.Audio.FirstOrDefaultAsync(f => f.AudioId == id);
                    if (audio == null)
                        return; 
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Audio", audio.UrlAidio);
                    File.Delete(filePath);
                    await _context.Audio
                        .Where(r => r.AudioId == id)
                        .ExecuteDeleteAsync();
                    break;
                case FileType.Pptx:
                    var pptx = await _context.Pptx.FirstOrDefaultAsync(f => f.PptxId == id);
                    if (pptx == null)
                        return;
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pptx", pptx.PptxUrl);
                    File.Delete(filePath);
                    await _context.Pptx
                        .Where(r => r.PptxId == id)
                        .ExecuteDeleteAsync();
                    break;
                default:
                    throw new InvalidOperationException("Invalid file type");
            }
        }
    }
}
