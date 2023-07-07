using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Domain.Exceptions;
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
            var result =  await _repository.RetrieveFineTuneJobInfoAsync(fineTuneJobId);

            if (result == null)
                throw new FineTuneJobNotFoundException();

            return result;
        }

        public async Task CancelFineTuneJobAsync(string fineTuneJobId)
        {
            await _repository.CancelFineTuneJobAsync(fineTuneJobId);
        }

        public async Task<IReadOnlyList<Event>> GetFineTuneEventsAsync(string fineTuneJobId)
        {
            var result = await _repository.ListFineTuneEventsAsync(fineTuneJobId);

            if (result == null)
                throw new FineTuneJobNotFoundException();

            return result;
        }
    }
}
