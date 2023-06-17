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
        [Authorize]
        public async Task<ActionResult<UserVM>> Create([FromBody] CreateUserVM src)
        {
            var userId = User.GetId();
            //var userId = "auth0testuser";
            if (userId == null)
                return BadRequest("Invalid Request");

            var result = await _userService.Create(src, userId);

            return Ok(result);
        }

        /// <summary>
        /// Deletes the signed in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteUser(string id)
        {
            // TODO: what happens to user's data and the auth0 

            var userId = User.GetId();
            await _userService.DeleteUser(id);
            return Ok();

        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UserVM>> Update([FromBody] UpdateUserVM data )
        {
            var userId = User.GetId();
            //var userId = "auth0testuser";
            var result = await _userService.Update(data, userId);
            return Ok(result);





        }

    }
}
