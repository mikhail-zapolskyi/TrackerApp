using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project777.Models.ViewModels.Users;
using Project777.Service.Interfaces;

namespace Project777.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create User in database
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserVM>> Create([FromBody] CreateUserVM src)
        {
            try
            {
                var result = await _userService.Create(src);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
