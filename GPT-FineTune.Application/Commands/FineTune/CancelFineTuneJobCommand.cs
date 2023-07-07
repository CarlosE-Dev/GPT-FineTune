using GPT_FineTune.Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GPT_FineTune.Application.Commands.FineTune
{
    public class CancelFineTuneJobCommand : IRequest<Unit>
    {
        [Required]
        public string FineTuneId { get; set; }
    }

    public class CancelFineTuneJobCommandHandler : IRequestHandler<CancelFineTuneJobCommand, Unit>
    {
        private readonly IFineTuneService _service;
        public CancelFineTuneJobCommandHandler(IFineTuneService service)
        {
            _service = service;
        }
        public async Task<Unit> Handle(CancelFineTuneJobCommand request, CancellationToken cancellationToken)
        {
            await _service.CancelFineTuneJobAsync(request.FineTuneId);

            return await Task.FromResult(Unit.Value);
        }
    }
}
