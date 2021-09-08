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
    public class UsersFavsArticleConfiguration : IEntityTypeConfiguration<UsersFavsArticle>
    {
        public void Configure(EntityTypeBuilder<UsersFavsArticle> builder)
        {
            builder.HasKey(x => new { x.UserID, x.ArticleID });

            builder.HasOne(x => x.Article)
                .WithMany(x => x.UsersFavsArticles)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UsersFavsArticles)
                .HasForeignKey(x => x.UserID);
        }
    }
}
