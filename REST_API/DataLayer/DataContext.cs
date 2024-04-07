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
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<QuestionAnswerMap>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.HasOne(u=>u.user)
                .WithOne(qa=>qa.QuestionAnswerMap)
                .HasForeignKey<QuestionAnswerMap>(qa=>qa.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(q=>q.question)
                .WithOne(qa=>qa.QuestionAnswerMap)
                .HasForeignKey<QuestionAnswerMap>(q=>q.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(q => q.answer)
                .WithOne(qa => qa.QuestionAnswerMap)
                .HasForeignKey<QuestionAnswerMap>(q => q.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(q => q.article)
                .WithOne(qa => qa.QuestionAnswerMap)
                .HasForeignKey<QuestionAnswerMap>(q => q.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);
            });
             

        }

    }
}
