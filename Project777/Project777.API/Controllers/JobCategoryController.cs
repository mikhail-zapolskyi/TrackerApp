using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project777.API.Helpers;
using Project777.Models.ViewModels.JobCategories;
using Project777.Models.ViewModels.Users;
using Project777.Services;
using Project777.Services.Interfaces;

namespace Project777.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryService _jobCategoryService;

        public JobCategoryController(IJobCategoryService jobCategoryService)
        {
            _jobCategoryService = jobCategoryService;
        }


        /// <summary>
        /// Create Category in database
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<JobCategoryVM>> Create([FromBody] CreateJobCategoryVM src)
        {
            var userId = User.GetId();
            //var userId = "auth0testuser";
            if (userId == null)
                return BadRequest("Invalid Request");

            var result = await _jobCategoryService.Create(src, userId);

            return Ok(result);
        }




    }
}
