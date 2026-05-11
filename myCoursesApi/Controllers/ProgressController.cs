namespace myCoursesApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using myCoursesApi.DTOs;
    using myCoursesApi.Interfaces;

    [ApiController]
    [Route("api/progress")]
    [Authorize]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;
        private readonly UserManager<IdentityUser> _userManager;

        public ProgressController(
            IProgressService progressService,
            UserManager<IdentityUser> userManager)
        {
            _progressService = progressService;
            _userManager = userManager;
        }

        // GET: /api/progress/{courseId}
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetProgress(string courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var progress = await _progressService.GetProgressAsync(user.Id, courseId);
            return Ok(progress);
        }

        // POST: /api/progress
        [HttpPost]
        public async Task<IActionResult> UpdateProgress(UpdateProgressDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            await _progressService.UpdateProgressAsync(user.Id, dto);
            return Ok();
        }
    }
}
