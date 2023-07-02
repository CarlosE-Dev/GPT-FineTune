using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Domain.Entities;
using MediatR;

namespace GPT_FineTune.Application.InputModels
{
    public class FormatTrainingDataInputModel : BaseInputModel, IRequest<string>
    {
        public IEnumerable<TrainingData> TrainingData { get; set; }
    }

    public class FormatTrainingDataInputModelHandler : IRequestHandler<FormatTrainingDataInputModel, string>
    {
        private readonly ITrainingDataService _service;
        public FormatTrainingDataInputModelHandler(ITrainingDataService service)
        {
            _service = service;
        }
        public async Task<string> Handle(FormatTrainingDataInputModel request, CancellationToken cancellationToken)
        {
            return await _service.GenerateTrainingData(request.TrainingData);
        }
    }
}
