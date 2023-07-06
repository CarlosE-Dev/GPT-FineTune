using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI;

namespace GPT_FineTune.Application.Queries.FineTune
{
    public class GetFineTuneEventsQuery : IRequest<IReadOnlyList<Event>>
    {
        public string FineTuneId { get; set; }
    }

    public class GetFineTuneEventsQueryHandler : IRequestHandler<GetFineTuneEventsQuery, IReadOnlyList<Event>>
    {
        private readonly IFineTuneService _service;
        public GetFineTuneEventsQueryHandler(IFineTuneService service)
        {
            _service = service;
        }

        public async Task<IReadOnlyList<Event>> Handle(GetFineTuneEventsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetFineTuneEventsAsync(request.FineTuneId);
        }
    }
}
