namespace myCoursesApi.DTOs
{
    public class SubmitQuizDto
    {
        public string CourseId { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }

    public class AnswerDto
    {
        public int QuestionId { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
