namespace myCoursesApi.DTOs
{
    public class QuizDto
    {
        public string CourseId { get; set; }
        public List<QuizQuestionDto> Questions { get; set; }
    }
}
