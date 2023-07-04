using OpenAI.Files;

namespace GPT_FineTune.Application.Interfaces
{
    public interface IFileApiRepository
    {
        Task<FileData> UploadFileAsync(string path, string purpose);
        Task<IReadOnlyList<FileData>> ListFilesAsync();
        Task<FileData> GetFileInfoAsync(string fileId);
        Task DeleteFileAsync(string fileId);
        Task DownloadFileAsync(string fileId, string path);
    }
}
