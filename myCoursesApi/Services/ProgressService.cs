namespace myCoursesApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using myCoursesApi.coursesData;
    using myCoursesApi.Data;
    using myCoursesApi.DTOs;
    using myCoursesApi.Interfaces;
    using System;
    using System.Text.Json;

    public class ProgressService : IProgressService
    {
        private readonly AuthDbContext _context;

        public ProgressService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<CourseProgressDto> GetProgressAsync(string userId, string courseId)
        {
            var progress = await _context.Progresses
                .FirstOrDefaultAsync(p => p.UserId == userId && p.CourseId == courseId);

            if (progress == null)
            {
                return new CourseProgressDto
                {
                    CourseId = courseId,
                    CompletedLessonIds = new List<string>(),
                    LastAccessedLessonId = null
                };
            }

            return new CourseProgressDto
            {
                CourseId = courseId,
                CompletedLessonIds = string.IsNullOrEmpty(progress.CompletedLessonIds)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(progress.CompletedLessonIds),
                LastAccessedLessonId = progress.LastAccessedLessonId
            };
        }

        public async Task UpdateProgressAsync(string userId, UpdateProgressDto dto)
        {
            var progress = await _context.Progresses
                .FirstOrDefaultAsync(p => p.UserId == userId && p.CourseId == dto.CourseId);

            List<string> completedLessons;

            if (progress == null)
            {
                completedLessons = new List<string>();

                progress = new Progress
                {
                    UserId = userId,
                    CourseId = dto.CourseId,
                    CompletedLessonIds = "",
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Progresses.Add(progress);
            }
            else
            {
                completedLessons = string.IsNullOrEmpty(progress.CompletedLessonIds)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(progress.CompletedLessonIds);
            }

            // Add lesson if not already completed
            if (!completedLessons.Contains(dto.LessonId))
            {
                completedLessons.Add(dto.LessonId);
            }

            progress.CompletedLessonIds = JsonSerializer.Serialize(completedLessons);
            progress.LastAccessedLessonId = dto.LessonId;
            progress.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
