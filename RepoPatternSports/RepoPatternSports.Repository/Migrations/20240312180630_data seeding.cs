using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoPatternSports.Repository.Migrations
{
    public partial class dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "UserId", "ContactNumber", "DateOfBirth", "Email", "Firstname", "Height", "Lastname", "Password", "TotalMatchesPlayed", "Weight", "isMember", "role" },
                values: new object[] { 1, "9726976891", new DateTime(2002, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "parangirathod27@gmail.com", "Parangi", 0, "Rathod", "a2b33e9987e8c254361bcafced58a245ea7ba919eaf093119694a68e01bd59fe", 0, 0, false, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
