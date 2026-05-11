namespace myCoursesApi.DTOs
{
    public class CourseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Difficulty { get; set; }
        public int LessonCount { get; set; }
    }
}
