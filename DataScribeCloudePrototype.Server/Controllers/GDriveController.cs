using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace DataScribeCloudePrototype.Server.Controllers
{
    public class GDriveController : Controller
    {
        private readonly GoogleService _googleService;

        public GDriveController(GoogleService googleService) {
            _googleService = googleService;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please select a file to upload.");

            try
            {
                await _googleService.UploadFile(file);
                return Ok("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while uploading the file: {ex.Message}");
            }
        }
    }
}
