using GPT_FineTune.Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GPT_FineTune.Application.Commands.Files
{
    public class UploadFileCommand : IRequest<Unit>
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Purpose { get; set; }
    }

    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Unit>
    {
        private readonly IFileService _service;
        public UploadFileCommandHandler(IFileService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            await _service.UploadFileAsync(request.FileName, request.Purpose);

            return await Task.FromResult(Unit.Value);
        }
    }
}
