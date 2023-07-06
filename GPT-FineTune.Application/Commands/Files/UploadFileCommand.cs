using GPT_FineTune.Application.Interfaces;
using MediatR;
using OpenAI.Files;
using System.ComponentModel.DataAnnotations;

namespace GPT_FineTune.Application.Commands.Files
{
    public class UploadFileCommand : IRequest<FileData>
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Purpose { get; set; }
    }

    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, FileData>
    {
        private readonly IFileService _service;
        public UploadFileCommandHandler(IFileService service)
        {
            _service = service;
        }

        public async Task<FileData> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            return await _service.UploadFileAsync(request.FileName, request.Purpose);
        }
    }
}
