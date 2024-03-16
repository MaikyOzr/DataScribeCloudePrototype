using DataScribeCloudePrototype.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IFileStorage
    {
        Task<IActionResult> SaveAudioFiles(IFormFile file);
        Task<IActionResult> SaveDocFiles(IFormFile file);
        Task<IActionResult> SaveImageFiles(IFormFile file);
        Task<IActionResult> SavePDFFiles(IFormFile file);
        void SaveNotes(Notes notes);
        Task<IActionResult> DeleteNotes(Notes notes);
        IActionResult GetFile(IFormFile file);
        Task<IActionResult> DeleteDocFile(IFormFile file);
        Task<IActionResult> DeleteAudioFiles(IFormFile file);
        Task<IActionResult> DeleteImageFiles(IFormFile file);
        Task<IActionResult> DeletePDFFiles(IFormFile file);
    }
}
