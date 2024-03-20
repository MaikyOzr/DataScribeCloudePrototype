using DataScribeCloudePrototype.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IFileStorage
    {
        void AddAudioFiles(IFormFile file);
        void AddDocFiles(IFormFile file);
        void AddImageFiles(IFormFile file);
        void AddPDFFiles(IFormFile file);
        Task AddNotes(Notes notes);
        void DeleteNotes(Notes notes);
        void GetFile(IFormFile file);
        void DeleteDocFile(IFormFile file);
        void DeleteAudioFiles(IFormFile file);
        void DeleteImageFiles(IFormFile file);
        void DeletePDFFiles(IFormFile file);
    }
}
