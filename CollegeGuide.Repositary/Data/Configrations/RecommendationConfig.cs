using CollegeGuide.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Repositary.Data.Configrations
{
    internal class RecommendationConfig : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.HasOne(r => r.User)
              .WithMany(u => u.Recommendations);
             

            builder.HasKey(r => r.Rec_Id);
            // تحديد المفتاح الأساسي
        }


    }
}
