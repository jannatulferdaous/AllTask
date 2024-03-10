using Microsoft.EntityFrameworkCore;
using REST_API.Models;
using REST_API.Response;

namespace REST_API.DataLayer
{
    public class DataContext:DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet <Article> Articles { get; set; }
        public DbSet<Question>Questions { get; set; }
        public DbSet<QAnswer> Answers { get; set; }
        public DbSet<QuestionAnswerMap> QuestionAnswerMaps { get; set; }
        public DbSet<UserArticle>  UserArticles { get; set; }
        public DbSet<User>  Users{ get; set; }
        public DbSet<QuestionView> QuestionViews { get; set; }
        public DbSet<AnswerView> AnswerViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserArticle>()
                .HasNoKey();
            modelBuilder.Entity<AnswerView>()
               .HasNoKey();
            modelBuilder.Entity<QuestionView>()
               .HasNoKey();

        }

    }
}
