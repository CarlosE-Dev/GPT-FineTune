using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI.FineTuning;

namespace GPT_FineTune.Application.Queries.FineTune
{
    public class GetFineTuneJobsQuery : IRequest<IReadOnlyList<FineTuneJob>>
    {
    }

    public class GetFineTuneJobsQueryHandler : IRequestHandler<GetFineTuneJobsQuery, IReadOnlyList<FineTuneJob>>
    {
        private readonly IFineTuneService _service;
        public GetFineTuneJobsQueryHandler(IFineTuneService service)
        {
            _service = service;
        }

        public async Task<IReadOnlyList<FineTuneJob>> Handle(GetFineTuneJobsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllFineTuningJobsAsync();
        }
    }
}
