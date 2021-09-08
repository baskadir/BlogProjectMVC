using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Teknoloji')");
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Bilim')");
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Yazılım')");
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Yapay Zeka')");
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Elektrikli Araçlar')");
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Seyahat')");
            migrationBuilder.Sql("INSERT INTO Topics (TopicName) Values('Uzay')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Topics");
        }
    }
}
