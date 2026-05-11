using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myCoursesApi.coursesData;

namespace myCoursesApi.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        protected AuthDbContext()
        {
        }
    }
}
