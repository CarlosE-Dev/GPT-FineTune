using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI.FineTuning;

namespace GPT_FineTune.Application.Queries.FineTune
{
    public class GetFineTuneJobQuery : IRequest<FineTuneJob>
    {
        public string FineTuneId { get; set; }
    }

    public class GetFineTuneJobQueryHandler : IRequestHandler<GetFineTuneJobQuery, FineTuneJob>
    {
        private readonly IFineTuneService _service;
        public GetFineTuneJobQueryHandler(IFineTuneService service)
        {
            _service = service;
        }

        public async Task<FineTuneJob> Handle(GetFineTuneJobQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetFineTuneJobInfoAsync(request.FineTuneId);
        }
    }
}
