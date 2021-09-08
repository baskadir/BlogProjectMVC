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
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleID);

            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x => x.CreatedTime).HasColumnType("date");
            builder.Property(x => x.CountClicked).HasDefaultValueSql("((0))");
            builder.Property(x => x.ReadingTime).HasMaxLength(20).IsUnicode(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.UserID);
        }
    }
}
