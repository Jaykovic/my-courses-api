namespace myCoursesApi.coursesData
{
    public class Lesson
    {
        public int Id { get; set; }

        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string LessonCode { get; set; } // "psr-1"
        public string Title { get; set; }

        public string Introduction { get; set; }
        public string MainContent { get; set; }

        public string KeyPointsJson { get; set; } // simple list storage
        public string CaseStudy { get; set; }
        public string Summary { get; set; }
    }
}
