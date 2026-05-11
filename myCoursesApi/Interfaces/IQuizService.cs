using myCoursesApi.DTOs;

namespace myCoursesApi.Interfaces
{
    public interface IQuizService
    {
        Task<QuizDto> GetQuizByCourseIdAsync(string courseId);
        Task<QuizResultDto> SubmitQuizAsync(string userId, SubmitQuizDto dto);
        Task<QuizResultDto> GetLatestResultAsync(string userId, string courseId);
    }
}
