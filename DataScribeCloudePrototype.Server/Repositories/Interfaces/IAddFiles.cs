using DataScribeCloudePrototype.Server.Repositories.Enums;

namespace DataScribeCloudePrototype.Server.Repositories.Interfaces
{
    public interface IAddFiles
    {
        Task<int> AddFile(FileType fileType, IFormFile file);
    }
}
