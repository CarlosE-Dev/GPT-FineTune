using GPT_FineTune.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.FineTuning;

namespace GPT_FineTune.Application.Services
{
    public class FineTuneService : IFineTuneService
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        private readonly OpenAIClient _httpClient;
        public FineTuneService(IConfiguration config)
        {
            _config = config;
            _apiKey = _config["OpenApiKey"];
            _httpClient = new OpenAIClient(new OpenAIAuthentication(_apiKey));
        }

        public async Task<IReadOnlyList<FineTuneJob>> GetAllFineTuningJobsAsync()
        {
            return await _httpClient.FineTuningEndpoint.ListFineTuneJobsAsync();
        }

        public async Task CreateFineTuneJobAsync(CreateFineTuneJobRequest request)
        {
            await _httpClient.FineTuningEndpoint.CreateFineTuneJobAsync(request);
        }

        public async Task<FineTuneJob> GetFineTuneJobInfoAsync(FineTuneJob job)
        {
            return await _httpClient.FineTuningEndpoint.RetrieveFineTuneJobInfoAsync(job);
        }

        public async Task CancelFineTuneJobAsync(FineTuneJob job)
        {
            var result = await _httpClient.FineTuningEndpoint.CancelFineTuneJobAsync(job);
        }

        public async Task<IReadOnlyList<Event>> GetFineTuneEventsAsync(FineTuneJob job)
        {
            return await _httpClient.FineTuningEndpoint.ListFineTuneEventsAsync(job);
        }
    }
}
