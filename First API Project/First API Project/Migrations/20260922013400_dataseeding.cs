using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstApiProject.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Capacity", "GradeLevel", "Name" },
                values: new object[,]
                {
                    { 1, 30, 1, "Room 101 - Alpha" },
                    { 2, 25, 2, "Room 202 - Beta" },
                    { 3, 35, 3, "Room 303 - Gamma" },
                    { 4, 20, 1, "Lab A - Computer Center" },
                    { 5, 22, 2, "Lab B - Science Hall" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineering and Architecture", "Computer Science" },
                    { 2, "Pure and Applied Mathematics", "Mathematics" },
                    { 3, "Classical and Quantum Mechanics", "Physics" },
                    { 4, "Big Data, Analytics, and AI Systems", "Data Science" },
                    { 5, "Business Technology Infrastructure", "Information Systems" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassRoomId", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2005, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.ali@example.com", "Ahmed", "Ali", "01023456789" },
                    { 2, 2, new DateTime(2006, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.k@example.com", "Sara", "Kamal", "01276543210" },
                    { 3, 1, new DateTime(2005, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.h@example.com", "Omar", "Hassan", "01145678901" },
                    { 4, 3, new DateTime(2004, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "yasmine.m@example.com", "Yasmine", "Moustafa", "01598765432" },
                    { 5, 2, new DateTime(2006, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "mostafa.m@example.com", "Mostafa", "Mahmoud", "01011223344" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "DepartmentId", "EmailAddress", "FirstName", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "j.doe@school.com", "John", "Doe", "+123456789", 5500.00m },
                    { 2, 2, "j.smith@school.com", "Jane", "Smith", "+987654321", 6000.00m },
                    { 3, 3, "r.johnson@school.com", "Robert", "Johnson", "+111222333", 5800.00m },
                    { 4, 4, "e.davis@school.com", "Emily", "Davis", "+444555666", 6200.00m },
                    { 5, 5, "m.brown@school.com", "Michael", "Brown", "+777888999", 5400.00m }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "MaxGrade", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Building backend systems with EF Core", 100, "Web Development API", 1 },
                    { 2, "Limits, derivatives, and integrations", 100, "Calculus I", 2 },
                    { 3, "Introduction to atomic structures", 100, "Quantum Physics", 3 },
                    { 4, "Supervised and unsupervised learning models", 100, "Machine Learning", 4 },
                    { 5, "SQL, normalization, and indexing patterns", 100, "Database Management Systems", 5 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "StudentId", "SubjectId", "EnrollmentDate", "Grade", "Id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.50m, 1 },
                    { 1, 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.00m, 2 },
                    { 2, 1, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.00m, 3 },
                    { 3, 4, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.75m, 4 },
                    { 4, 3, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.00m, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
