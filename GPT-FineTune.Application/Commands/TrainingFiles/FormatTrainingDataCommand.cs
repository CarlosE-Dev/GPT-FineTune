using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GPT_FineTune.Application.Commands.TrainingFiles
{
    public class FormatTrainingDataCommand : BaseCommand, IRequest<string>
    {
        [Required]
        public IEnumerable<TrainingData> TrainingData { get; set; }
    }

    public class FormatTrainingDataCommandHandler : IRequestHandler<FormatTrainingDataCommand, string>
    {
        private readonly ITrainingDataService _service;
        public FormatTrainingDataCommandHandler(ITrainingDataService service)
        {
            _service = service;
        }
        public async Task<string> Handle(FormatTrainingDataCommand request, CancellationToken cancellationToken)
        {
            return await _service.GenerateTrainingData(request.TrainingData);
        }
    }
}
