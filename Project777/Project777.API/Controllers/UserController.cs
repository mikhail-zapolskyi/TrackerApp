using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project777.API.Helpers;
using Project777.Models.ViewModels.Users;
using Project777.Services.Interfaces;

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
        //[Authorize]
        public async Task<ActionResult<UserVM>> Create([FromBody] CreateUserVM src)
        {
            try
            {

                // var userId = User.GetId();
                var userId = "auth0testuser";
                if (userId == null)
                    return BadRequest("Invalid Request");

                var result = await _userService.Create(src, userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut()]
        public async Task<ActionResult<UserVM>> Update([FromBody] UpdateUserVM data)
        {
            try
            {
                // update user from the service
                var result = await _userService.Update(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

    }
}
