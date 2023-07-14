using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project777.API.Helpers;
using Project777.Models.ViewModels.Jobs;
using Project777.Models.ViewModels.Users;
using Project777.Services.Interfaces;

namespace Project777.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        /// <summary>
        /// Create Job in database
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<JobVM>> Create([FromBody] CreateJobVM src)
        {
            var userId = User.GetId();
            if (userId == null)
                return BadRequest("Invalid Request");

            var result = await _jobService.Create(src, userId);

            return Ok(result);
        }

        [HttpGet]
        [Authorize]

        public string GetAll()
        {
           
            return ("Get All Jobs");
        }
    }
}
