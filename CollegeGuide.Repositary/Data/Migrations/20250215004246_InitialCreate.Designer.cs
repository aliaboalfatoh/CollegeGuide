﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollegeGuide.Repositary.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20250215004246_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollegeGuide.Core.Entities.College", b =>
                {
                    b.Property<int>("Col_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Col_Id"));

                    b.Property<float>("AppFeesEgy")
                        .HasColumnType("real");

                    b.Property<float>("AppFeesInternational")
                        .HasColumnType("real");

                    b.Property<string>("ColDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("DurationOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("FeesEgy")
                        .HasColumnType("real");

                    b.Property<float>("FeesInternational")
                        .HasColumnType("real");

                    b.Property<float>("FirstInstallment")
                        .HasColumnType("real");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SecInstallment")
                        .HasColumnType("real");

                    b.Property<int>("Uni_Id")
                        .HasColumnType("int");

                    b.HasKey("Col_Id");

                    b.HasIndex("Uni_Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.FinancialAid", b =>
                {
                    b.Property<int>("Aid_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Aid_Id"));

                    b.Property<string>("AidDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aid_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Uni_Id")
                        .HasColumnType("int");

                    b.HasKey("Aid_Id");

                    b.HasIndex("Uni_Id");

                    b.ToTable("FinancialAids");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.Recommendation", b =>
                {
                    b.Property<int>("Rec_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rec_Id"));

                    b.Property<int>("Col_Id")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Uni_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UniversityUni_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Rec_Id");

                    b.HasIndex("Col_Id");

                    b.HasIndex("UniversityUni_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.University", b =>
                {
                    b.Property<int>("Uni_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Uni_Id"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("UniDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Uni_Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.College", b =>
                {
                    b.HasOne("CollegeGuide.Core.Entities.University", "University")
                        .WithMany("Colleges")
                        .HasForeignKey("Uni_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.FinancialAid", b =>
                {
                    b.HasOne("CollegeGuide.Core.Entities.University", "University")
                        .WithMany("FinancialAids")
                        .HasForeignKey("Uni_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.Recommendation", b =>
                {
                    b.HasOne("CollegeGuide.Core.Entities.College", "College")
                        .WithMany("Recommendations")
                        .HasForeignKey("Col_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollegeGuide.Core.Entities.University", null)
                        .WithMany("Recommendations")
                        .HasForeignKey("UniversityUni_Id");

                    b.HasOne("CollegeGuide.Core.Entities.User", "User")
                        .WithMany("Recommendations")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.College", b =>
                {
                    b.Navigation("Recommendations");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.University", b =>
                {
                    b.Navigation("Colleges");

                    b.Navigation("FinancialAids");

                    b.Navigation("Recommendations");
                });

            modelBuilder.Entity("CollegeGuide.Core.Entities.User", b =>
                {
                    b.Navigation("Recommendations");
                });
#pragma warning restore 612, 618
        }
    }
}
