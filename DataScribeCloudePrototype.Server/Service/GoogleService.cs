using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DataScribeCloudePrototype.Server.Service
{
    public class GoogleService
    {
        private readonly string[] Scopes = { DriveService.Scope.Drive };
        private readonly string ApplicationName = "DataScribeCloud";
        private readonly string ClientSecretJsonPath;

        public GoogleService()
        {
            var clientSecret = Environment.GetEnvironmentVariable("CREDENTIAL");
            ClientSecretJsonPath = Path.GetTempFileName();
            File.WriteAllText(ClientSecretJsonPath, clientSecret);
        }

        public async Task UploadFile(IFormFile file)
        {
            GoogleCredential credential;

            using (var stream = new FileStream(ClientSecretJsonPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file.FileName
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = file.OpenReadStream())
            {
                request = service.Files.Create(fileMetadata, stream, file.ContentType);
                request.Fields = "id";
                await request.UploadAsync();
            }

            var uploadedFile = request.ResponseBody;
        }
    }
}
