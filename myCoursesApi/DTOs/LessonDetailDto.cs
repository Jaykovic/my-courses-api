namespace myCoursesApi.DTOs
{
    public class LessonDetailDto
    {
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public string Title { get; set; }

        public string Introduction { get; set; }
        public string MainContent { get; set; }
        public List<string> KeyPoints { get; set; }
        public string CaseStudy { get; set; }
        public string Summary { get; set; }
    }
}
