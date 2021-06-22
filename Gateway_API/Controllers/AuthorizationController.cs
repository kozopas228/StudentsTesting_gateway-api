using Gateway_API.ViewModels;
using Gateway_Services.Interfaces;
using Gateway_Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _service;

        public AuthorizationController(IAuthorizationService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _service.Login(model.Login, model.Password);

            if (result == "")
            {
                return Unauthorized();
            }

            return Content(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _service.Register(model.Login, model.Password, model.FirstName, model.LastName);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetUserIdByLogin")]
        public async Task<IActionResult> GetUserId(string login)
        {
            return Content((await _service.GetUserIdByLogin(login)).ToString());
        }

        [HttpGet("GetUserAttempts")]
        public async Task<IActionResult> GetAttemptsById(Guid id)
        {
            return new JsonResult(await _service.GetUserAttempts(id));
        }

        [HttpGet("ChangeUserRole")]
        public async Task<IActionResult> ChangeRole(Guid userId, string role)
        {
            await _service.ChangeUserRole(userId, role);
            return Ok();
        }

        [HttpGet("AddNewAttemptToUser")]
        public async Task<IActionResult> AddUserAttempt(Guid userId, Guid testId)
        {
            await _service.AddAttemptToUser(userId, testId);
            return Ok();
        }

        [HttpGet("ChangeUserLogin")]
        public async Task<IActionResult> ChangeUserLogin(Guid userId, string newLogin)
        {
            var result = await _service.ChangeUserLogin(userId, newLogin);
            if (result) return Ok();
            return BadRequest();
        }
        [HttpGet("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword(Guid userId, string newPassword)
        {
            var result = await _service.ChangeUserPassword(userId, newPassword);
            if (result) return Ok();
            return BadRequest();
        }
        [HttpGet("ChangeUserFirstName")]
        public async Task<IActionResult> ChangeUserFirstName(Guid userId, string newFirstName)
        {
            var result = await _service.ChangeUserFirstName(userId, newFirstName);
            if (result) return Ok();
            return BadRequest();
        }
        [HttpGet("ChangeUserLastName")]
        public async Task<IActionResult> ChangeUserLastName(Guid userId, string newLastName)
        {
            var result = await _service.ChangeUserLastName(userId, newLastName);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpPost("SaveAttemptToUser")]
        public async Task<IActionResult> SaveAttempt(Guid userId, TestAttempt attempt)
        {
            var result = await _service.SaveAttemptToUser(userId, attempt);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetAllUsers()
        {
            return new JsonResult(await _service.GetAllUsersAsync());
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _service.CreateUserAsync(user);
            return Ok();
        }

        [HttpPut("User")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var result = await _service.UpdateUserAsync(user);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _service.DeleteUserAsync(id);
            if (result) return NoContent();
            return NotFound();
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            var users = await _service.GetAllUsersAsync();
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return new JsonResult(user);
        }



        [HttpGet("TestAttempt")]
        public async Task<IActionResult> GetAllTestAttempts()
        {
            return new JsonResult(await _service.GetAllTestAttemptsAsync());
        }

        [HttpPost("TestAttempt")]
        public async Task<IActionResult> CreateTestAttempt([FromBody] TestAttempt TestAttempt)
        {
            await _service.CreateTestAttemptAsync(TestAttempt);
            return Ok();
        }

        [HttpPut("TestAttempt")]
        public async Task<IActionResult> UpdateTestAttempt([FromBody] TestAttempt TestAttempt)
        {
            var result = await _service.UpdateTestAttemptAsync(TestAttempt);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("TestAttempt/{id}")]
        public async Task<IActionResult> DeleteTestAttempt(Guid id)
        {
            var result = await _service.DeleteTestAttemptAsync(id);
            if (result) return NoContent();
            return NotFound();
        }

        [HttpGet("TestAttempt/{id}")]
        public async Task<IActionResult> GetByTestAttemptId(Guid id)
        {
            var TestAttempts = await _service.GetAllTestAttemptsAsync();
            var TestAttempt = TestAttempts.FirstOrDefault(x => x.Id == id);

            if (TestAttempt == null)
            {
                return NotFound();
            }

            return new JsonResult(TestAttempt);
        }


    }
}
