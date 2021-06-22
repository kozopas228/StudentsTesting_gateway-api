using Gateway_Services.Interfaces;
using Gateway_Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gateway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _service;

        public ProcessController(IProcessService service)
        {
            _service = service;
        }

        [HttpGet("MixQuestions")]
        public async Task<IActionResult> MixQuestions(Guid testId)
        {
            try
            {
                return new JsonResult(await _service.MixQuestions(testId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("CheckAnswer")]
        public async Task<IActionResult> CheckAnswer([FromBody] CheckAnswerViewModel viewModel)
        {
            try
            {
                return new JsonResult(await _service.CheckAnswer(viewModel));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
