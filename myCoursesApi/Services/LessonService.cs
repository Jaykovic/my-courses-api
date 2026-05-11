namespace myCoursesApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using myCoursesApi.Data;
    using myCoursesApi.DTOs;
    using myCoursesApi.Interfaces;
    using System;
    using System.Text.Json;

    public class LessonService : ILessonService
    {
        private readonly AuthDbContext _context;

        public LessonService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<List<LessonListDto>> GetLessonsByCourseIdAsync(string courseId)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                .OrderBy(l => l.Id)
                .Select(l => new LessonListDto
                {
                    Id = l.Id,
                    LessonCode = l.LessonCode,
                    Title = l.Title
                })
                .ToListAsync();
        }

        public async Task<LessonDetailDto> GetLessonByIdAsync(int lessonId)
        {
            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null) return null;

            return new LessonDetailDto
            {
                Id = lesson.Id,
                LessonCode = lesson.LessonCode,
                Title = lesson.Title,
                Introduction = lesson.Introduction,
                MainContent = lesson.MainContent,
                KeyPoints = string.IsNullOrEmpty(lesson.KeyPointsJson)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(lesson.KeyPointsJson),
                CaseStudy = lesson.CaseStudy,
                Summary = lesson.Summary
            };
        }
    }
}
