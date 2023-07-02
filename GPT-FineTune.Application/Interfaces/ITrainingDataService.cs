using GPT_FineTune.Domain.Entities;

namespace GPT_FineTune.Application.Interfaces
{
    public interface ITrainingDataService
    {
        Task<string> GenerateTrainingData(IEnumerable<TrainingData> trainingData);
    }
}
