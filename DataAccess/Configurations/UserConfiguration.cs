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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserID);

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.FullName).HasMaxLength(50);

            builder.Property(x => x.PhotoName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(x => x.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
