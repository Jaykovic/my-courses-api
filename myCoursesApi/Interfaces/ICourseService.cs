using myCoursesApi.DTOs;

namespace myCoursesApi.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(string id);
    }
}
