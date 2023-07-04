using GPT_FineTune.Application.Interfaces;
using OpenAI;
using OpenAI.Files;

namespace GPT_FineTune.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileApiRepository _repository;
        public FileService(IFileApiRepository repository)
        {
            _repository = repository;
        }

        public async Task<FileData> UploadFileAsync(string fileName, string purpose)
        {
            var defaultPath = GetDefaultPath("TrainingFiles", fileName);

            return await _repository.UploadFileAsync(Path.Combine(defaultPath, fileName), purpose);
        }

        public async Task<IReadOnlyList<FileData>> GetAllFilesAsync()
        {
            return await _repository.ListFilesAsync();
        }

        public async Task<FileData> GetFileInfoAsync(string fileId)
        {
            return await _repository.GetFileInfoAsync(fileId);
        }

        public async Task DeleteFileAsync(string fileId)
        {
            await _repository.DeleteFileAsync(fileId);
        }

        public async Task<string> DownloadFileAsync(string fileId)
        {
            var defaultPath = GetDefaultPath("FileDownloads");
            await _repository.DownloadFileAsync(fileId, defaultPath);

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
