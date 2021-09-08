using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ArticlesTopicConfiguration : IEntityTypeConfiguration<ArticlesTopic>
    {
        public void Configure(EntityTypeBuilder<ArticlesTopic> builder)
        {
            builder.HasKey(x => new {x.ArticleID,x.TopicID});

            builder.HasOne(x => x.Article)
                .WithMany(x => x.ArticlesTopics)
                .HasForeignKey(x => x.ArticleID);

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.ArticlesTopics)
                .HasForeignKey(x => x.TopicID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
