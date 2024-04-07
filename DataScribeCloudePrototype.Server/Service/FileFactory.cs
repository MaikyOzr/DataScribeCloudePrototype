using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Repositories.Enums;
using DataScribeCloudePrototype.Server.Models;

namespace DataScribeCloudePrototype.Server.Service;

public class FileFactory
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager _manager;

    public FileFactory(ApplicationDbContext context, UserManager manager)
    {
        _context = context;
        _manager = manager;
    }

    public async Task<int> AddFile(FileType fileType, IFormFile file) 
    {
        var userId = _manager.GetCurrUserId();
        var filePath = await SaveFileAsync(fileType, file);
        switch (fileType) 
        {
            case FileType.Doc:
                return await AddFileToDataBase(new DocFiles { DocUrl = filePath, CurrUserID = userId });
            case FileType.Image:
                return await AddFileToDataBase(new Images { UrlImage = filePath, CurrUserID = userId });
            case FileType.PDF:
                return await AddFileToDataBase(new Pdf { PDFUrl = filePath, CurrUserID = userId });
            case FileType.Audio:
                return await AddFileToDataBase(new Audio { UrlAidio = filePath, CurrUserID = userId });
            case FileType.Pptx:
                return await AddFileToDataBase(new Pptx { PptxUrl = filePath, CurrUserID = userId });
            default:
                throw new InvalidOperationException("Invalid file type");
        }
        
    }

    private async Task<int> AddFileToDataBase<T>(T file) where T : class
    { 
        _context.Set<T>().Add(file);
        await _context.SaveChangesAsync();
        dynamic dynamicFile = file;
        return dynamicFile.Id;
    }

    private async Task<string> SaveFileAsync(FileType fileType, IFormFile file)
    {
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileType.ToString());
        var originalFileName = Path.GetFileName(file.FileName);
        var sanitizedFileName = RemoveInvalidFileNameChars(originalFileName);
        var filePath = Path.Combine(uploadFolder, sanitizedFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return sanitizedFileName;
    }

    private string RemoveInvalidFileNameChars(string fileName) 
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        return string.Join("", fileName.Split(invalidChars));
    }
}
