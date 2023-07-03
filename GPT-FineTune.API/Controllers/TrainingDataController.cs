using GPT_FineTune.Application.Commands.TrainingFiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPT_FineTune.API.Controllers
{
    [ApiController]
    [Route("api/v1/training-data")]
    public class TrainingDataController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainingDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("format")]
        public async Task<IActionResult> FormatTrainingData(FormatTrainingDataCommand input)
        {
            try
            {
                return Ok(await _mediator.Send(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
