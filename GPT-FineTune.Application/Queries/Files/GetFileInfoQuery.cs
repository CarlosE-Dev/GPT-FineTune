using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI.Files;

namespace GPT_FineTune.Application.Queries.Files
{
    public class GetFileInfoQuery : IRequest<FileData>
    {
        public string FileId { get; private set; }

        public GetFileInfoQuery(string fileId)
        {
            FileId = fileId;
        }
    }

    public class GetFileInfoQueryHandler : IRequestHandler<GetFileInfoQuery, FileData>
    {
        private readonly IFileService _service;
        public GetFileInfoQueryHandler(IFileService service)
        {
            _service = service;
        }

        public async Task<FileData> Handle(GetFileInfoQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetFileInfoAsync(request.FileId);
        }
    }
}
