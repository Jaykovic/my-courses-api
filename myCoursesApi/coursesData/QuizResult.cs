namespace myCoursesApi.coursesData
{
    public class QuizResult
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string CourseId { get; set; }

        public int Score { get; set; }
        public int Total { get; set; }
        public double Percentage { get; set; }

        public DateTime TakenAt { get; set; }
    }
}
