namespace myCoursesApi.coursesData
{
    public class Quiz
    {
        public int Id { get; set; }

        public string CourseId { get; set; }
        public Course Course { get; set; }

        public List<QuizQuestion> Questions { get; set; }
    }
}
