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
    internal class FinancialAidConfig : IEntityTypeConfiguration<FinancialAid>
    {
        public void Configure(EntityTypeBuilder<FinancialAid> builder)
        {
            builder.HasOne(fa => fa.University)
              .WithMany(u => u.FinancialAids)
              .HasForeignKey(fa => fa.Uni_Id);

            builder.HasKey(fa => fa.Aid_Id); // تحديد المفتاح الأساسي
        }

    }

       

    }
