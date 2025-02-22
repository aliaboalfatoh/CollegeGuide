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
    internal class UniversityConfig : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasMany(u => u.Colleges)
               .WithOne(c => c.University)
               .HasForeignKey(c => c.Uni_Id);

            builder.HasMany(u => u.FinancialAids)
                   .WithOne(fa => fa.University)
                   .HasForeignKey(fa => fa.Uni_Id);
        }
    }
}
