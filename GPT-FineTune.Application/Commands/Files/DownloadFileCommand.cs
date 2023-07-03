using GPT_FineTune.Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GPT_FineTune.Application.Commands.Files
{
    public class DownloadFileCommand : IRequest<string>
    {
        [Required]
        public string FileId { get; set; }
    }

    public class DownloadFileCommandHandler : IRequestHandler<DownloadFileCommand, string>
    {
        private readonly IFileService _service;

        public DownloadFileCommandHandler(IFileService service)
        {
            _service = service;
        }

        public async Task<string> Handle(DownloadFileCommand request, CancellationToken cancellationToken)
        {
            return await _service.DownloadFileAsync(request.FileId);
        }
    }
}
