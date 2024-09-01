using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalprojectbanking.Migrations
{
    /// <inheritdoc />
    public partial class MoneyTrans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Moneyold",
                table: "MoneyTranss",
                newName: "MoneyOld");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoneyOld",
                table: "MoneyTranss",
                newName: "Moneyold");
        }
    }
}
