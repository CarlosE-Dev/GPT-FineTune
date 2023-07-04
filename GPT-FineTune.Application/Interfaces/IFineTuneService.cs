using OpenAI.FineTuning;
using OpenAI;
using GPT_FineTune.Application.Commands.FineTune;

namespace GPT_FineTune.Application.Interfaces
{
    public interface IFineTuneService
    {
        Task<IReadOnlyList<FineTuneJob>> GetAllFineTuningJobsAsync();
        Task<FineTuneJob> CreateFineTuneJobAsync(CreateFineTuneJobRequest request);
        Task<FineTuneJob> GetFineTuneJobInfoAsync(string fineTuneJobId);
        Task CancelFineTuneJobAsync(string fineTuneJobId);
        Task<IReadOnlyList<Event>> GetFineTuneEventsAsync(string fineTuneJobId);
    }
}
