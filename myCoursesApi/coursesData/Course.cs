namespace myCoursesApi.coursesData
{
    public class Course
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Difficulty { get; set; }

        public List<Lesson> Lessons { get; set; } = new();
        public List<Quiz> Quizzes { get; set; } = new();
    }
}
