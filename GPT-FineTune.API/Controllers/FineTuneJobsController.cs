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
    }
}
