namespace myCoursesApi.coursesData
{
    public class Progress
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string CompletedLessonIds { get; set; }
        public string LastAccessedLessonId { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
