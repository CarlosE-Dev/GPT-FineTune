using GPT_FineTune.Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GPT_FineTune.Application.Commands.Files
{
    public class DeleteFileCommand : IRequest<Unit>
    {
        [Required]
        public string FileId { get; set; }
    }

    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Unit>
    {
        private readonly IFileService _service;
        public DeleteFileCommandHandler(IFileService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteFileAsync(request.FileId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
