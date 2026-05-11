namespace myCoursesApi.DTOs
{
    public class CourseProgressDto
    {
        public string CourseId { get; set; }
        public List<string> CompletedLessonIds { get; set; }
        public string LastAccessedLessonId { get; set; }
    }
}
