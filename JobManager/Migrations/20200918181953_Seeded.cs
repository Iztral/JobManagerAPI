using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManager.Migrations
{
    public partial class Seeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "Completed", "Description", "EstimatedCompletionDate", "Priority", "Title" },
                values: new object[,]
                {
                    { 22, false, "Task to be compleated.", null, 1, "Task 1" },
                    { 19, false, "Task to be compleated.", null, 1, "Task 20" },
                    { 18, false, "Task to be compleated.", null, 1, "Task 19" },
                    { 17, false, "Task to be compleated.", null, 1, "Task 18" },
                    { 16, false, "Task to be compleated.", null, 1, "Task 17" },
                    { 15, false, "Task to be compleated.", null, 1, "Task 16" },
                    { 14, false, "Task to be compleated.", null, 1, "Task 15" },
                    { 13, false, "Task to be compleated.", null, 1, "Task 14" },
                    { 12, false, "Task to be compleated.", null, 1, "Task 13" },
                    { 11, false, "Task to be compleated.", null, 1, "Task 12" },
                    { 10, false, "Task to be compleated.", null, 1, "Task 11" },
                    { 9, false, "Task to be compleated.", null, 1, "Task 10" },
                    { 8, false, "Task to be compleated.", null, 1, "Task 9" },
                    { 7, false, "Task to be compleated.", null, 1, "Task 8" },
                    { 6, false, "Task to be compleated.", null, 1, "Task 7" },
                    { 5, false, "Task to be compleated.", null, 1, "Task 6" },
                    { 4, false, "Task to be compleated.", null, 1, "Task 5" },
                    { 3, false, "Task to be compleated.", null, 1, "Task 4" },
                    { 2, false, "Task to be compleated.", null, 1, "Task 3" },
                    { 1, false, "Task to be compleated.", null, 1, "Task 2" },
                    { 20, false, "Task to be compleated.", null, 1, "Task 21" },
                    { 21, false, "Task to be compleated.", null, 1, "Task 22" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 22);
        }
    }
}
