using myCoursesApi.DTOs;

namespace myCoursesApi.Interfaces
{
    public interface IProgressService
    {
        Task<CourseProgressDto> GetProgressAsync(string userId, string courseId);
        Task UpdateProgressAsync(string userId, UpdateProgressDto dto);
    }
}
