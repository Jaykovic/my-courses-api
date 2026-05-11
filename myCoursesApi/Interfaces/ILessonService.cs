using myCoursesApi.DTOs;

namespace myCoursesApi.Interfaces
{
    public interface ILessonService
    {
        Task<List<LessonListDto>> GetLessonsByCourseIdAsync(string courseId);
        Task<LessonDetailDto> GetLessonByIdAsync(int lessonId);
    }
}
