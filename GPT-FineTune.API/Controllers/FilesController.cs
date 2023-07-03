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

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllFilesQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("info/{fileId:string}")]
        public async Task<IActionResult> GetFileInfo([FromRoute] string fileId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetFileInfoQuery(fileId)));
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
                await _mediator.Send(input);
                return Created("", input);
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
