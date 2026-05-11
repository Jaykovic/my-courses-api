namespace myCoursesApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using myCoursesApi.coursesData;
    using myCoursesApi.Data;
    using myCoursesApi.DTOs;
    using myCoursesApi.Interfaces;
    using System;
    using System.Text.Json;

    public class QuizService : IQuizService
    {
        private readonly AuthDbContext _context;

        public QuizService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<QuizDto> GetQuizByCourseIdAsync(string courseId)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.CourseId == courseId);

            if (quiz == null) return null;

            return new QuizDto
            {
                CourseId = courseId,
                Questions = quiz.Questions.Select(q => new QuizQuestionDto
                {
                    Id = q.Id,
                    Question = q.Question,
                    Options = JsonSerializer.Deserialize<List<string>>(q.OptionsJson)
                }).ToList()
            };
        }

        public async Task<QuizResultDto> SubmitQuizAsync(string userId, SubmitQuizDto dto)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.CourseId == dto.CourseId);

            if (quiz == null) return null;

            int score = 0;
            int total = quiz.Questions.Count;

            foreach (var question in quiz.Questions)
            {
                var answer = dto.Answers
                    .FirstOrDefault(a => a.QuestionId == question.Id);

                if (answer != null && answer.SelectedAnswer == question.CorrectAnswer)
                {
                    score++;
                }
            }

            double percentage = total == 0 ? 0 : (double)score / total * 100;

            var result = new QuizResult
            {
                UserId = userId,
                CourseId = dto.CourseId,
                Score = score,
                Total = total,
                Percentage = percentage,
                TakenAt = DateTime.UtcNow
            };

            _context.QuizResults.Add(result);
            await _context.SaveChangesAsync();

            return new QuizResultDto
            {
                Score = score,
                Total = total,
                Percentage = percentage
            };
        }

        public async Task<QuizResultDto> GetLatestResultAsync(string userId, string courseId)
        {
            var result = await _context.QuizResults
                .Where(r => r.UserId == userId && r.CourseId == courseId)
                .OrderByDescending(r => r.TakenAt)
                .FirstOrDefaultAsync();

            if (result == null) return null;

            return new QuizResultDto
            {
                Score = result.Score,
                Total = result.Total,
                Percentage = result.Percentage
            };
        }
    }
}
