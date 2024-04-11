using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentManagerSystem.Models;

public partial class QuanLiSinhVienContext : DbContext
{
    public QuanLiSinhVienContext()
    {
    }

    public QuanLiSinhVienContext(DbContextOptions<QuanLiSinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Academicyear> Academicyears { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    // ko dung o day
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=THANH-TAI\\SQLEXPRESS01;Initial Catalog=QuanLiSinhVien;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Academicyear>(entity =>
        {
            entity.ToTable("ACADEMICYEAR");

            entity.Property(e => e.AcademicyearId)
                .HasMaxLength(50)
                .HasColumnName("ACADEMICYEAR_ID");
            entity.Property(e => e.Year).HasColumnName("YEAR");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("ACCOUNT");

            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("ROLE");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN");

            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.AdminId)
                .HasMaxLength(50)
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("GENDER");
            entity.Property(e => e.Phone).HasColumnName("PHONE");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_ADMIN_ACCOUNT");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("CLASS");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("CLASS_ID");
            entity.Property(e => e.AcademicyearId)
                .HasMaxLength(50)
                .HasColumnName("ACADEMICYEAR_ID");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .HasColumnName("CLASS_NAME");
            entity.Property(e => e.CourseId)
                .HasMaxLength(50)
                .HasColumnName("COURSE_ID");

            entity.HasOne(d => d.Academicyear).WithMany(p => p.Classes)
                .HasForeignKey(d => d.AcademicyearId)
                .HasConstraintName("FK_CLASS_ACADEMICYEAR");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CLASS_COURSE");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("COURSE");

            entity.Property(e => e.CourseId)
                .HasMaxLength(50)
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .HasColumnName("COURSE_NAME");
            entity.Property(e => e.Enddate)
                .HasColumnType("datetime")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Startdate)
                .HasColumnType("datetime")
                .HasColumnName("STARTDATE");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.ToTable("INSTRUCTOR");

            entity.Property(e => e.InstructorId)
                .HasMaxLength(50)
                .HasColumnName("INSTRUCTOR_ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("CLASS_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("GENDER");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");

            entity.HasOne(d => d.Account).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_INSTRUCTOR_ACCOUNT");

            entity.HasOne(d => d.Class).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_INSTRUCTOR_CLASS");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_RESULT_1");

            entity.ToTable("RESULT");

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("CLASS_ID");
            entity.Property(e => e.FinalGrade).HasColumnName("FINAL_GRADE");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.MediumScore).HasColumnName("MEDIUM_SCORE");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .HasColumnName("SUBJECT_ID");
            entity.Property(e => e.Testscore1st).HasColumnName("TESTSCORE_1ST");
            entity.Property(e => e.Testscore2nd).HasColumnName("TESTSCORE_2ND");

            entity.HasOne(d => d.Class).WithMany(p => p.Results)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_RESULT_CLASS");

            entity.HasOne(d => d.Student).WithOne(p => p.Result)
                .HasForeignKey<Result>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESULT_STUDENT");

            entity.HasOne(d => d.Subject).WithMany(p => p.Results)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_RESULT_SUBJECT");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("STUDENT");

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .HasColumnName("CLASS_ID");
            entity.Property(e => e.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("GENDER");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .HasColumnName("SUBJECT_ID");

            entity.HasOne(d => d.Account).WithMany(p => p.Students)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_STUDENT_ACCOUNT1");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("SUBJECT");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .HasColumnName("SUBJECT_ID");
            entity.Property(e => e.CourseId)
                .HasMaxLength(50)
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.InstructorId)
                .HasMaxLength(50)
                .HasColumnName("INSTRUCTOR_ID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .HasColumnName("SUBJECT_NAME");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(50)
                .HasColumnName("INSTRUCTOR_NAME");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("TEST");

            entity.Property(e => e.TestId)
                .HasMaxLength(50)
                .HasColumnName("TEST_ID");
            entity.Property(e => e.AcademicyearId)
                .HasMaxLength(50)
                .HasColumnName("ACADEMICYEAR_ID");
            entity.Property(e => e.CourseId)
                .HasMaxLength(50)
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .HasColumnName("SUBJECT_ID");
            entity.Property(e => e.TestDate)
                .HasColumnType("datetime")
                .HasColumnName("TEST_DATE");
            entity.Property(e => e.TestName)
                .HasMaxLength(50)
                .HasColumnName("TEST_NAME");

            entity.HasOne(d => d.Academicyear).WithMany(p => p.Tests)
                .HasForeignKey(d => d.AcademicyearId)
                .HasConstraintName("FK_TEST_ACADEMICYEAR");

            entity.HasOne(d => d.Course).WithMany(p => p.Tests)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_TEST_COURSE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
