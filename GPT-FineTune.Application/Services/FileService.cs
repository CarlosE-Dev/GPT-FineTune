using GPT_FineTune.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Files;

namespace GPT_FineTune.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        private readonly OpenAIClient _httpClient;

        public FileService(IConfiguration config)
        {
            _config = config;
            _apiKey = _config["OpenApiKey"];
            _httpClient = new OpenAIClient(new OpenAIAuthentication(_apiKey));
        }

        public async Task UploadFileAsync(string fileName, string purpose)
        {
            var defaultPath = GetDefaultPath("TrainingFiles", fileName);
            await _httpClient.FilesEndpoint.UploadFileAsync(Path.Combine(defaultPath, fileName), purpose);
        }

        public async Task<IReadOnlyList<FileData>> GetAllFilesAsync()
        {
            return await _httpClient.FilesEndpoint.ListFilesAsync();
        }

        public async Task<FileData> GetFileInfoAsync(string fileId)
        {
            return await _httpClient.FilesEndpoint.GetFileInfoAsync(fileId);
        }

        public async Task DeleteFileAsync(string fileId)
        {
            await _httpClient.FilesEndpoint.DeleteFileAsync(fileId);
        }

        public async Task<string> DownloadFileAsync(string fileId)
        {
            var defaultPath = GetDefaultPath("FileDownloads");
            await _httpClient.FilesEndpoint.DownloadFileAsync(fileId, defaultPath);

            return $"Path: {defaultPath}";
        }

        private string GetDefaultPath(string folderName, string fileName = "")
        {
            var defaultPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(defaultPath))
                Directory.CreateDirectory(defaultPath);

            if(!string.IsNullOrWhiteSpace(fileName))
            {
                if (!fileName.Contains(".jsonl"))
                    fileName += ".jsonl";

                return Path.Combine(defaultPath, fileName);
            }

            return defaultPath;
        }
    }
}
