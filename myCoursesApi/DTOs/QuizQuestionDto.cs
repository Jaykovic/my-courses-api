namespace myCoursesApi.DTOs
{
    public class QuizQuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
    }
}
