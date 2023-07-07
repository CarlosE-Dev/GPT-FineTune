using GPT_FineTune.Application.Commands.FineTune;
using GPT_FineTune.Application.Queries.FineTune;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GPT_FineTune.API.Controllers
{
    [ApiController]
    [Route("api/v1/fine-tune")]
    public class FineTuneJobsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FineTuneJobsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateFineTuneJob(CreateFineTuneJobCommand request)
        {
            try
            {
                return Created("", await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


            [HttpGet("list")]
        public async Task<IActionResult> ListFineTuneJobs()
        {
            try
            {
                return Ok(await _mediator.Send(new GetFineTuneJobsQuery()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> GetFineTuneJob([FromRoute] string id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetFineTuneJobQuery { FineTuneId = id }));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelFineTuneJob([FromRoute] string id)
        {
            try
            {
                await _mediator.Send(new CancelFineTuneJobCommand { FineTuneId = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("events/{id}")]
        public async Task<IActionResult> ListFineTuneEvents([FromRoute] string id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetFineTuneEventsQuery { FineTuneId = id }));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
