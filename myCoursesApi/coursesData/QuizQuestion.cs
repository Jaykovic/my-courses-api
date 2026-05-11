namespace myCoursesApi.coursesData
{
    public class QuizQuestion
    {
        public int Id { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public string Question { get; set; }
        public string OptionsJson { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
