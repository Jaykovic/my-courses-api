using Microsoft.AspNetCore.Mvc;
using myCoursesApi.Interfaces;

namespace myCoursesApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        // GET: /api/courses/{courseId}/lessons
        [HttpGet("courses/{courseId}/lessons")]
        public async Task<IActionResult> GetLessonsByCourse(string courseId)
        {
            var lessons = await _lessonService.GetLessonsByCourseIdAsync(courseId);
            return Ok(lessons);
        }

        // GET: /api/lessons/{lessonId}
        [HttpGet("lessons/{lessonId}")]
        public async Task<IActionResult> GetLesson(int lessonId)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(lessonId);

            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }
    }
}
