using Microsoft.EntityFrameworkCore;
using CollegeGuide.Core.Entities;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);

        modelBuilder.Entity<University>()
         .HasKey(u => u.Uni_Id); // التأكيد على أن Uni_Id هو الـ Primary Key

        modelBuilder.Entity<University>()
            .Property(u => u.Uni_Id)
            .ValueGeneratedOnAdd(); // توليد القيمة تلقائيًا

        modelBuilder.Entity<College>()
            .HasKey(c => c.Col_Id);

        modelBuilder.Entity<College>()
            .HasOne(c => c.University)
            .WithMany(u => u.Colleges)
            .HasForeignKey(c => c.Uni_Id);

        modelBuilder.Entity<FinancialAid>()
            .HasKey(f => f.Aid_Id);

        modelBuilder.Entity<FinancialAid>()
            .HasOne(fa => fa.University)
            .WithMany(u => u.FinancialAids)
            .HasForeignKey(fa => fa.Uni_Id);

        modelBuilder.Entity<User>()
            .HasKey(u => u.User_Id);

        modelBuilder.Entity<Recommendation>()
            .HasKey(r => r.Rec_Id);

        modelBuilder.Entity<Recommendation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Recommendations)
            .HasForeignKey(r => r.User_Id);

        modelBuilder.Entity<Recommendation>()
            .HasOne(r => r.College)
            .WithMany(c => c.Recommendations)
            .HasForeignKey(r => r.Col_Id);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<College> Colleges { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<FinancialAid> FinancialAids { get; set; }
}
