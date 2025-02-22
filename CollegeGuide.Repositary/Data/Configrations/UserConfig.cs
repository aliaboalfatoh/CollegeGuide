using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeGuide.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeGuide.Repositary.Data.Configrations
{
    internal class UserConfig : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Recommendations)
              .WithOne(r => r.User)
              .HasForeignKey(r => r.User_Id);
            builder.HasKey(fa => fa.User_Id); // تحديد المفتاح الأساسي

            builder.Property(P => P.Name).IsRequired();
            builder.Property(P => P.UserType).IsRequired();
        }
    }
}
