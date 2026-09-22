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
            optionsBuilder.UseSqlServer("Server=DESKTOP-513950Q\\SQLEXPRESS01;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;");
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

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { Id = 1, Name = "Room 101 - Alpha", GradeLevel = 1, Capacity = 30 },
                new Classroom { Id = 2, Name = "Room 202 - Beta", GradeLevel = 2, Capacity = 25 },
                new Classroom { Id = 3, Name = "Room 303 - Gamma", GradeLevel = 3, Capacity = 35 },
                new Classroom { Id = 4, Name = "Lab A - Computer Center", GradeLevel = 1, Capacity = 20 },
                new Classroom { Id = 5, Name = "Lab B - Science Hall", GradeLevel = 2, Capacity = 22 }
            );

            // 2. Seed Departments (5 Records)
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", Description = "Software Engineering and Architecture" },
                new Department { Id = 2, Name = "Mathematics", Description = "Pure and Applied Mathematics" },
                new Department { Id = 3, Name = "Physics", Description = "Classical and Quantum Mechanics" },
                new Department { Id = 4, Name = "Data Science", Description = "Big Data, Analytics, and AI Systems" },
                new Department { Id = 5, Name = "Information Systems", Description = "Business Technology Infrastructure" }
            );

            // 3. Seed Students (5 Records)
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Ahmed", LastName = "Ali", EmailAddress = "ahmed.ali@example.com", PhoneNumber = "01023456789", DateOfBirth = new DateTime(2005, 5, 12), ClassRoomId = 1 },
                new Student { Id = 2, FirstName = "Sara", LastName = "Kamal", EmailAddress = "sara.k@example.com", PhoneNumber = "01276543210", DateOfBirth = new DateTime(2006, 8, 20), ClassRoomId = 2 },
                new Student { Id = 3, FirstName = "Omar", LastName = "Hassan", EmailAddress = "omar.h@example.com", PhoneNumber = "01145678901", DateOfBirth = new DateTime(2005, 11, 3), ClassRoomId = 1 },
                new Student { Id = 4, FirstName = "Yasmine", LastName = "Moustafa", EmailAddress = "yasmine.m@example.com", PhoneNumber = "01598765432", DateOfBirth = new DateTime(2004, 3, 15), ClassRoomId = 3 },
                new Student { Id = 5, FirstName = "Mostafa", LastName = "Mahmoud", EmailAddress = "mostafa.m@example.com", PhoneNumber = "01011223344", DateOfBirth = new DateTime(2006, 1, 28), ClassRoomId = 2 }
            );

            // 4. Seed Teachers (5 Records)
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "j.doe@school.com", PhoneNumber = "+123456789", Salary = 5500.00m, DepartmentId = 1 },
                new Teacher { Id = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "j.smith@school.com", PhoneNumber = "+987654321", Salary = 6000.00m, DepartmentId = 2 },
                new Teacher { Id = 3, FirstName = "Robert", LastName = "Johnson", EmailAddress = "r.johnson@school.com", PhoneNumber = "+111222333", Salary = 5800.00m, DepartmentId = 3 },
                new Teacher { Id = 4, FirstName = "Emily", LastName = "Davis", EmailAddress = "e.davis@school.com", PhoneNumber = "+444555666", Salary = 6200.00m, DepartmentId = 4 },
                new Teacher { Id = 5, FirstName = "Michael", LastName = "Brown", EmailAddress = "m.brown@school.com", PhoneNumber = "+777888999", Salary = 5400.00m, DepartmentId = 5 }
            );

            // 5. Seed Subjects (5 Records)
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Web Development API", Description = "Building backend systems with EF Core", MaxGrade = 100, TeacherId = 1 },
                new Subject { Id = 2, Name = "Calculus I", Description = "Limits, derivatives, and integrations", MaxGrade = 100, TeacherId = 2 },
                new Subject { Id = 3, Name = "Quantum Physics", Description = "Introduction to atomic structures", MaxGrade = 100, TeacherId = 3 },
                new Subject { Id = 4, Name = "Machine Learning", Description = "Supervised and unsupervised learning models", MaxGrade = 100, TeacherId = 4 },
                new Subject { Id = 5, Name = "Database Management Systems", Description = "SQL, normalization, and indexing patterns", MaxGrade = 100, TeacherId = 5 }
            );

            // 6. Seed Enrollments (5 Records - Matching StudentId and SubjectId combinations)
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, SubjectId = 1, EnrollmentDate = new DateTime(2026, 9, 1), Grade = 92.50m },
                new Enrollment { Id = 2, StudentId = 1, SubjectId = 2, EnrollmentDate = new DateTime(2026, 9, 1), Grade = 88.00m },
                new Enrollment { Id = 3, StudentId = 2, SubjectId = 1, EnrollmentDate = new DateTime(2026, 9, 2), Grade = 95.00m },
                new Enrollment { Id = 4, StudentId = 3, SubjectId = 4, EnrollmentDate = new DateTime(2026, 9, 3), Grade = 89.75m },
                new Enrollment { Id = 5, StudentId = 4, SubjectId = 3, EnrollmentDate = new DateTime(2026, 9, 4), Grade = 91.00m }
            );
        }
    }
}
