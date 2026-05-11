namespace myCoursesApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using myCoursesApi.Data;
    using myCoursesApi.DTOs;
    using myCoursesApi.Interfaces;
    using System;

    public class CourseService : ICourseService
    {
        private readonly AuthDbContext _context;

        public CourseService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Lessons)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Image = c.Image,
                    Difficulty = c.Difficulty,
                    LessonCount = c.Lessons.Count
                })
                .ToListAsync();
        }

        public async Task<CourseDto> GetCourseByIdAsync(string id)
        {
            var course = await _context.Courses
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return null;

            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Image = course.Image,
                Difficulty = course.Difficulty,
                LessonCount = course.Lessons.Count
            };
        }
    }
}
