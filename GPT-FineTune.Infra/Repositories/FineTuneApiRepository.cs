using GPT_FineTune.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.FineTuning;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace GPT_FineTune.Infra.Repositories
{
    public class FineTuneApiRepository : IFineTuneApiRepository
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        private readonly string _openAIUrl;
        private readonly OpenAIClient _openAIHttpClient;
        private readonly HttpClient _httpClient;
        public FineTuneApiRepository(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _apiKey = _config["ApiKey"];
            _openAIUrl = _config["OpenAIUrl"];
            _openAIHttpClient = new OpenAIClient(new OpenAIAuthentication(_apiKey));
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyList<FineTuneJob>> ListFineTuneJobsAsync()
        {
            try
            {
                return await _openAIHttpClient.FineTuningEndpoint.ListFineTuneJobsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FineTuneJob> CreateFineTuneJobAsync(CreateFineTuneJobRequest request)
        {
            _httpClient.BaseAddress = new Uri(_openAIUrl);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            try
            {
                StringContent contentRequest = new StringContent(JsonSerializer.Serialize(request, GetSerializerOptions()), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("fine-tunes", contentRequest).ConfigureAwait(continueOnCapturedContext: false);

                return JsonSerializer.Deserialize<FineTuneJob>(await response.Content.ReadAsStringAsync());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FineTuneJob> RetrieveFineTuneJobInfoAsync(string fineTuneJobId)
        {
            try
            {
                return await _openAIHttpClient.FineTuningEndpoint.RetrieveFineTuneJobInfoAsync(fineTuneJobId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CancelFineTuneJobAsync(string fineTuneJobId)
        {
            try
            {
                await _openAIHttpClient.FineTuningEndpoint.CancelFineTuneJobAsync(fineTuneJobId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IReadOnlyList<Event>> ListFineTuneEventsAsync(string fineTuneJobId)
        {
            try
            {
                return await _openAIHttpClient.FineTuningEndpoint.ListFineTuneEventsAsync(fineTuneJobId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private JsonSerializerOptions GetSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { (JsonConverter)new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
        }
    }
}
