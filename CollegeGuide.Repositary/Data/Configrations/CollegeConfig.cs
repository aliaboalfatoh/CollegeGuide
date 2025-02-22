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
        internal class CollegeConfig : IEntityTypeConfiguration<College>
        {
            public void Configure(EntityTypeBuilder<College> builder)
            {
                builder.HasOne(c => c.University)
                     .WithMany(u => u.Colleges)
                     .HasForeignKey(c => c.Uni_Id);
            }


        }
    }
