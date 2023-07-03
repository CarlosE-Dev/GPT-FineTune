using OpenAI.Files;

namespace GPT_FineTune.Application.Interfaces
{
    public interface IFileService
    {
        Task<IReadOnlyList<FileData>> GetAllFilesAsync();
        Task<FileData> GetFileInfoAsync(string fileId);
        Task UploadFileAsync(string fileName, string purpose);
        Task DeleteFileAsync(string fileId);
        Task<string> DownloadFileAsync(string fileId);
    }
}
