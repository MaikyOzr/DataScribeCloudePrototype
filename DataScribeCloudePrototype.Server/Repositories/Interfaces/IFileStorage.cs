
namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IFileStorage
    {
        Task UpdateNotes(int id,string title, string content);
        void AddAudioFiles(IFormFile file);
        void AddDocFiles(IFormFile file);
        Task<int> AddImageFiles(IFormFile file);
        void AddPDFFiles(IFormFile file);
        Task<int> AddNotes(string title, string content);
        Task DeleteNotes(int id);
        void GetFile(IFormFile file);
        void DeleteDocFile(IFormFile file);
        void DeleteAudioFiles(IFormFile file);
        Task DeleteImageFiles(int id);
        void DeletePDFFiles(IFormFile file);
    }
}
