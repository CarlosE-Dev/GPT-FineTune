using OpenAI.FineTuning;
using OpenAI;
using GPT_FineTune.Application.Commands.FineTune;

namespace GPT_FineTune.Application.Interfaces
{
    public interface IFineTuneService
    {
        Task<IReadOnlyList<FineTuneJob>> GetAllFineTuningJobsAsync();
        Task CreateFineTuneJobAsync(CreateFineTuneJobRequest request);
        Task<FineTuneJob> GetFineTuneJobInfoAsync(FineTuneJob job);
        Task CancelFineTuneJobAsync(FineTuneJob job);
        Task<IReadOnlyList<Event>> GetFineTuneEventsAsync(FineTuneJob job);
    }
}
