﻿// <auto-generated />
using System;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    [Migration("20220312194133_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Concrete.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Duration")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<short>("NumberOfQuestions")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SuccessGrade")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Entities.Concrete.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExamId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Entities.Concrete.QuestionAnswer", b =>
                {
                    b.Property<int>("QuestionAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Option1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("QuestionAnswerId");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("Entities.Concrete.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserMail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserSurname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExamUser", b =>
                {
                    b.Property<int>("ExamsExamId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ExamsExamId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("ExamUser");
                });

            modelBuilder.Entity("Entities.Concrete.Exam", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany("Exams")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Concrete.Question", b =>
                {
                    b.HasOne("Entities.Concrete.Category", null)
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Entities.Concrete.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Entities.Concrete.QuestionAnswer", b =>
                {
                    b.HasOne("Entities.Concrete.Question", "Question")
                        .WithOne("QuestionAnswer")
                        .HasForeignKey("Entities.Concrete.QuestionAnswer", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Entities.Concrete.SubCategory", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ExamUser", b =>
                {
                    b.HasOne("Entities.Concrete.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamsExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Questions");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Entities.Concrete.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Entities.Concrete.Question", b =>
                {
                    b.Navigation("QuestionAnswer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
