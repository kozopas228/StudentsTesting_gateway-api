using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway_Services.Interfaces;
using Gateway_Services.Models;

namespace Gateway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudService _crudService;

        public CrudController(ICrudService crudService)
        {
            _crudService = crudService;
        }

        [HttpGet("Answer")]
        public async Task<IActionResult> GetAllAnswers()
        {
            return new JsonResult(await _crudService.GetAllAnswersAsync());
        }

        [HttpPost("Answer")]
        public async Task<IActionResult> CreateAnswer([FromBody] Answer answer)
        {
            return Ok(await _crudService.CreateAnswerAsync(answer));
        }

        [HttpPut("Answer")]
        public async Task<IActionResult> UpdateAnswer(Answer answer)
        {
            var result = await _crudService.UpdateAnswerAsync(answer);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("Answer/{id}")]
        public async Task<IActionResult> DeleteAnswerById(Guid id)
        {
            var result = await _crudService.DeleteAnswerAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("Answer/{id}")]
        public async Task<IActionResult> GetAnswerById(Guid id)
        {
            var allAnswers = await _crudService.GetAllAnswersAsync();

            if (allAnswers.Any(x => x.Id == id))
            {
                return new JsonResult(allAnswers.First(x => x.Id == id));
            }

            return NotFound();
        }

        [HttpGet("Question")]
        public async Task<IActionResult> GetAllQuestions()
        {
            return new JsonResult(await _crudService.GetAllQuestionsAsync());
        }

        [HttpPost("Question")]
        public async Task<IActionResult> CreateQuestion([FromBody] Question Question)
        {
            return Ok(await _crudService.CreateQuestionAsync(Question));
        }

        [HttpPut("Question")]
        public async Task<IActionResult> UpdateQuestion(Question Question)
        {
            var result = await _crudService.UpdateQuestionAsync(Question);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("Question/{id}")]
        public async Task<IActionResult> DeleteQuestionById(Guid id)
        {
            var result = await _crudService.DeleteQuestionAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("Question/{id}")]
        public async Task<IActionResult> GetQuestionById(Guid id)
        {
            var allQuestions = await _crudService.GetAllQuestionsAsync();

            if (allQuestions.Any(x => x.Id == id))
            {
                return new JsonResult(allQuestions.First(x => x.Id == id));
            }

            return NotFound();
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetAllTests()
        {
            return new JsonResult(await _crudService.GetAllTestsAsync());
        }

        [HttpPost("Test")]
        public async Task<IActionResult> CreateTest([FromBody] Test Test)
        {
            return Ok(await _crudService.CreateTestAsync(Test));
        }

        [HttpPut("Test")]
        public async Task<IActionResult> UpdateTest(Test Test)
        {
            var result = await _crudService.UpdateTestAsync(Test);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("Test/{id}")]
        public async Task<IActionResult> DeleteTestById(Guid id)
        {
            var result = await _crudService.DeleteTestAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("Test/{id}")]
        public async Task<IActionResult> GetTestById(Guid id)
        {
            var allTests = await _crudService.GetAllTestsAsync();

            if (allTests.Any(x => x.Id == id))
            {
                return new JsonResult(allTests.First(x => x.Id == id));
            }

            return NotFound();
        }

        [HttpGet("TestTheme")]
        public async Task<IActionResult> GetAllTestThemes()
        {
            return new JsonResult(await _crudService.GetAllTestThemesAsync());
        }

        [HttpPost("TestTheme")]
        public async Task<IActionResult> CreateTestTheme([FromBody] TestTheme TestTheme)
        {
            return Ok(await _crudService.CreateTestThemeAsync(TestTheme));
        }

        [HttpPut("TestTheme")]
        public async Task<IActionResult> UpdateTestTheme(TestTheme TestTheme)
        {
            var result = await _crudService.UpdateTestThemeAsync(TestTheme);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("TestTheme/{id}")]
        public async Task<IActionResult> DeleteTestThemeById(Guid id)
        {
            var result = await _crudService.DeleteTestThemeAsync(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("TestTheme/{id}")]
        public async Task<IActionResult> GetTestThemeById(Guid id)
        {
            var allTestThemes = await _crudService.GetAllTestThemesAsync();

            if (allTestThemes.Any(x => x.Id == id))
            {
                return new JsonResult(allTestThemes.First(x => x.Id == id));
            }

            return NotFound();
        }
    }
}
