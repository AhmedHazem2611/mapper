using Microsoft.EntityFrameworkCore;

namespace FirstApiProject.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TEST;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.Subjects)
                .WithOne(t => t.Teacher)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Classroom>()
                .HasMany(s => s.Students)
                .WithOne(c => c.Classroom)
                .HasForeignKey(s => s.ClassRoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Enrollments)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new {e.StudentId, e.SubjectId});

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Id)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(s => s.Id)
                .IsUnique();

            modelBuilder.Entity<Student>()
            .HasIndex(s => s.EmailAddress)
            .IsUnique();

            modelBuilder.Entity<Teacher>()
            .HasIndex(s => s.EmailAddress)
            .IsUnique();

            modelBuilder.Entity<Department>()
            .HasIndex(s => s.Name)
            .IsUnique();

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Salary)
                .HasPrecision(15, 2);
            modelBuilder.Entity<Classroom>()
                .HasData
                (
                 new Classroom { Id = 1, Name = "Classroom A" , GradeLevel = 1, Capacity=20 },
                 new Classroom { Id = 2, Name = "Classroom b", GradeLevel = 2, Capacity = 20 },
                 new Classroom { Id = 3, Name = "Classroom c", GradeLevel = 3, Capacity = 20 }
                );
        }
    }
}
