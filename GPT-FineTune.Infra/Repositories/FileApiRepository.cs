using GPT_FineTune.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Files;

namespace GPT_FineTune.Infra.Repositories
{
    public class FileApiRepository : IFileApiRepository
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        private readonly OpenAIClient _openAIHttpClient;

        public FileApiRepository(IConfiguration config)
        {
            _config = config;
            _apiKey = _config["ApiKey"];
            _openAIHttpClient = new OpenAIClient(new OpenAIAuthentication(_apiKey));
        }

        public async Task<FileData> UploadFileAsync(string path, string purpose)
        {
            try
            {
                return await _openAIHttpClient.FilesEndpoint.UploadFileAsync(path, purpose);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IReadOnlyList<FileData>> ListFilesAsync()
        {
            try
            {
                return await _openAIHttpClient.FilesEndpoint.ListFilesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FileData> GetFileInfoAsync(string fileId)
        {
            try
            {
                return await _openAIHttpClient.FilesEndpoint.GetFileInfoAsync(fileId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteFileAsync(string fileId)
        {
            try
            {
                await _openAIHttpClient.FilesEndpoint.DeleteFileAsync(fileId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DownloadFileAsync(string fileId, string path)
        {
            try
            {
                await _openAIHttpClient.FilesEndpoint.DownloadFileAsync(fileId, path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
