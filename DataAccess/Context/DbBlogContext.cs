using DataAccess.Configurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DbBlogContext:DbContext
    {
        public DbBlogContext(DbContextOptions<DbBlogContext> options):base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ArticlesTopic> ArticlesTopics { get; set; }
        public DbSet<UsersTopic> UsersTopics { get; set; }
        public DbSet<UsersFavsArticle> UsersFavsArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new ArticlesTopicConfiguration());
            modelBuilder.ApplyConfiguration(new UsersFavsArticleConfiguration());
            modelBuilder.ApplyConfiguration(new UsersTopicConfiguration());
        }
    }
}
