using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeZebra.Invoices.ReadModel.EntityFramework.Migrations
{
    public partial class TTitle_Title_Typo_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TTitle",
                table: "Invoices",
                "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Invoices",
                "TTitle");
        }
    }
}
