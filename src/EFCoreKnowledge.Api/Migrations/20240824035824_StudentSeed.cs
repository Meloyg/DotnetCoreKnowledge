using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreKnowledge.Api.Migrations
{
    /// <inheritdoc />
    public partial class StudentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "IsRegularStudent", "Name" },
                values: new object[,]
                {
                    { new Guid("014cebb0-f375-4a5b-bef4-bcc772debc28"), 30, true, "John Smith" },
                    { new Guid("49b359fd-e37f-4dc2-a7d6-18393ccec5d8"), 25, true, "John Doe" },
                    { new Guid("f8e9ce51-40e3-4bf3-a336-814b4e83775e"), 22, false, "Jane Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("014cebb0-f375-4a5b-bef4-bcc772debc28"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("49b359fd-e37f-4dc2-a7d6-18393ccec5d8"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f8e9ce51-40e3-4bf3-a336-814b4e83775e"));
        }
    }
}
