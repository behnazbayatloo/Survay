using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survay.Migrations
{
    /// <inheritdoc />
    public partial class addotalquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalQuestionCount",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQuestionCount",
                table: "Polls");
        }
    }
}
