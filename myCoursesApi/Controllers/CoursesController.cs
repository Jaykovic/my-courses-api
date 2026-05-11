namespace myCoursesApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using myCoursesApi.Interfaces;

    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(string id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }
    }
}
