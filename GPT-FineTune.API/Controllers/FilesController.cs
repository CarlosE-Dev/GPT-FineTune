using GPT_FineTune.Application.Commands.Files;
using GPT_FineTune.Application.Queries.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPT_FineTune.API.Controllers
{
    [ApiController]
    [Route("api/v1/files")]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllFilesQuery()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetFileInfo([FromRoute] string id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetFileInfoQuery(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromBody] UploadFileCommand input)
        {
            try
            {
                return Created("", await _mediator.Send(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("download")]
        public async Task<IActionResult> DownloadFile([FromBody] DownloadFileCommand command)
        {
            try
            {
                return Created("", await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFiles([FromBody] DeleteFileCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
