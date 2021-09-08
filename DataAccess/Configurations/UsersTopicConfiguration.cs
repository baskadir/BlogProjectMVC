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
    public class UsersTopicConfiguration : IEntityTypeConfiguration<UsersTopic>
    {
        public void Configure(EntityTypeBuilder<UsersTopic> builder)
        {
            builder.HasKey(x => new { x.UserID, x.TopicID });

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.UsersTopics)
                .HasForeignKey(x => x.TopicID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x =>x.User)
                .WithMany(x => x.UsersTopics)
                .HasForeignKey(x => x.UserID);
        }
    }
}
