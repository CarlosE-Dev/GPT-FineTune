using GPT_FineTune.Application.Commands.FineTune;
using GPT_FineTune.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OpenAI.FineTuning;

namespace GPT_FineTune.API.Controllers
{
    [ApiController]
    [Route("api/v1/fine-tune")]
    public class FineTuneController : ControllerBase
    { 
        private readonly IFineTuneService _service;
        public FineTuneController(IFineTuneService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFineTuneJob(CreateFineTuneJobCommand request)
        {
            try
            {
                await _service.CreateFineTuneJobAsync(request); 
                return Created("", request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListFineTuningJobs()
        {
            try
            {
                var response = await _service.ListFineTuningJobsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("info")]
        public async Task<IActionResult> RetrieveFineTuneJobInfo(FineTuneJob job)
        {
            try
            {
                var response = await _service.RetrieveFineTuneJobInfoAsync(job);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelFineTuneJob(FineTuneJob job)
        {
            try
            {
                await _service.CancelFineTuneJobAsync(job);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("events")]
        public async Task<IActionResult> ListFineTuneEvents(FineTuneJob job)
        {
            try
            {
                var response = await _service.ListFineTuneEventsAsync(job);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
