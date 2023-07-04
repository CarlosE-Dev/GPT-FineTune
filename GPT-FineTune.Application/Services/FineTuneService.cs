using GPT_FineTune.Application.Interfaces;
using OpenAI;
using OpenAI.FineTuning;

namespace GPT_FineTune.Application.Services
{
    public class FineTuneService : IFineTuneService
    {
        private readonly IFineTuneApiRepository _repository;
        public FineTuneService(IFineTuneApiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<FineTuneJob>> GetAllFineTuningJobsAsync()
        {
            return await _repository.ListFineTuneJobsAsync();
        }

        public async Task<FineTuneJob> CreateFineTuneJobAsync(CreateFineTuneJobRequest request)
        {
            return await _repository.CreateFineTuneJobAsync(request);
        }

        public async Task<FineTuneJob> GetFineTuneJobInfoAsync(string fineTuneJobId)
        {
            return await _repository.RetrieveFineTuneJobInfoAsync(fineTuneJobId);
        }

        public async Task CancelFineTuneJobAsync(string fineTuneJobId)
        {
            await _repository.CancelFineTuneJobAsync(fineTuneJobId);
        }

        public async Task<IReadOnlyList<Event>> GetFineTuneEventsAsync(string fineTuneJobId)
        {
            return await _repository.ListFineTuneEventsAsync(fineTuneJobId);
        }
    }
}
