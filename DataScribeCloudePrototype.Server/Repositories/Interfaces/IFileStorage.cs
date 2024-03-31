
namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IFileStorage
    {
        Task UpdateNotes(int id, string title, string content);
        void AddAudioFiles(IFormFile file);
        Task<int> AddDocFiles(IFormFile file);
        Task<int> AddImageFiles(IFormFile file);
        Task<int> AddPDFFiles(IFormFile file);
        Task<int> AddNotes(string title, string content);
        Task DeleteNotes(int id);
        Task DeleteDocFile(int id);
        void DeleteAudioFiles(IFormFile file);
        Task DeleteImageFiles(int id);
        Task DeletePDFFiles(int id);
    }
}
