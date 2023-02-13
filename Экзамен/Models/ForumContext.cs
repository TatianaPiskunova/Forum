using Microsoft.EntityFrameworkCore;


namespace Экзамен.Models
{
    public class ForumContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        //public DbSet<TopicPost> TopicPosts { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
          Database.EnsureCreated();
        }
    }
}
