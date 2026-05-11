namespace myCoursesApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using myCoursesApi.DTOs;
    using myCoursesApi.Interfaces;

    [ApiController]
    [Route("api/quiz")]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly UserManager<IdentityUser> _userManager;

        public QuizController(
            IQuizService quizService,
            UserManager<IdentityUser> userManager)
        {
            _quizService = quizService;
            _userManager = userManager;
        }

        // GET: /api/quiz/{courseId}
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetQuiz(string courseId)
        {
            var quiz = await _quizService.GetQuizByCourseIdAsync(courseId);

            if (quiz == null)
                return NotFound();

            return Ok(quiz);
        }

        // POST: /api/quiz/submit
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz(SubmitQuizDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var result = await _quizService.SubmitQuizAsync(user.Id, dto);
            return Ok(result);
        }

        // GET: /api/quiz/result/{courseId}
        [HttpGet("result/{courseId}")]
        public async Task<IActionResult> GetResult(string courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var result = await _quizService.GetLatestResultAsync(user.Id, courseId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
