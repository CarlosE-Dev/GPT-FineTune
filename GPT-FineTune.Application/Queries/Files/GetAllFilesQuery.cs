using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI.Files;

namespace GPT_FineTune.Application.Queries.Files
{
    public class GetAllFilesQuery : IRequest<IReadOnlyList<FileData>>
    { 
    }

    public class GetAllFilesQueryHandler : IRequestHandler<GetAllFilesQuery, IReadOnlyList<FileData>>
    {
        private readonly IFileService _service;
        public GetAllFilesQueryHandler(IFileService service)
        {
            _service = service;
        }

        public async Task<IReadOnlyList<FileData>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllFilesAsync();
        }
    }
}
