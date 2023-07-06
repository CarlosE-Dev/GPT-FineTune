using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI.FineTuning;
using System.Text.Json.Serialization;

namespace GPT_FineTune.Application.Commands.FineTune
{
    public class CreateFineTuneJobCommand : IRequest<FineTuneJob>
    {
        [JsonPropertyName("training_file")]
        public string TrainingFileId { get; set; }

        [JsonPropertyName("validation_file")]
        public string ValidationFileId { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("n_epochs")]
        public int Epochs { get; set; }

        [JsonPropertyName("batch_size")]
        public double? BatchSize { get; set; }

        [JsonPropertyName("learning_rate_multiplier")]
        public double? LearningRateMultiplier { get; set; }

        [JsonPropertyName("prompt_loss_weight")]
        public double PromptLossWeight { get; set; }

        [JsonPropertyName("compute_classification_metrics")]
        public bool ComputeClassificationMetrics { get; set; }

        [JsonPropertyName("classification_n_classes")]
        public int? ClassificationNClasses { get; set; }

        [JsonPropertyName("classification_positive_class")]
        public string ClassificationPositiveClasses { get; set; }

        [JsonPropertyName("classification_betas")]
        public IReadOnlyList<double> ClassificationBetas { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
    }

    public class CreateFineTuneCommandHandler : IRequestHandler<CreateFineTuneJobCommand, FineTuneJob>
    {
        private readonly IFineTuneService _service;
        public CreateFineTuneCommandHandler(IFineTuneService service)
        {
            _service = service;
        }
        public async Task<FineTuneJob> Handle(CreateFineTuneJobCommand request, CancellationToken cancellationToken)
        {
            var createRequest = new CreateFineTuneJobRequest(
                request.TrainingFileId, 
                request.ValidationFileId, 
                request.Model, 
                (uint)request.Epochs, 
                request.BatchSize, 
                request.LearningRateMultiplier, 
                request.PromptLossWeight, 
                request.ComputeClassificationMetrics, 
                request.ClassificationNClasses, 
                request.ClassificationPositiveClasses, 
                request.ClassificationBetas, 
                request.Suffix
            );

            return await _service.CreateFineTuneJobAsync(createRequest);
        }
    }
}
