using OpenAI;
using OpenAI.FineTuning;

namespace GPT_FineTune.Application.Interfaces
{
    public interface IFineTuneApiRepository
    {
        Task<IReadOnlyList<FineTuneJob>> ListFineTuneJobsAsync();
        Task<FineTuneJob> CreateFineTuneJobAsync(CreateFineTuneJobRequest request);
        Task<FineTuneJob> RetrieveFineTuneJobInfoAsync(string fineTuneJobId);
        Task CancelFineTuneJobAsync(string fineTuneJobId);
        Task<IReadOnlyList<Event>> ListFineTuneEventsAsync(string fineTuneJobId);
    }
}
