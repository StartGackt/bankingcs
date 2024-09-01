using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalprojectbanking.Migrations
{
    /// <inheritdoc />
    public partial class AddMoneyTransTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyTranss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    IdCard = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: false),
                    Moneyold = table.Column<string>(type: "TEXT", nullable: false),
                    MoneyLast = table.Column<string>(type: "TEXT", nullable: false),
                    MoneyTotal = table.Column<string>(type: "TEXT", nullable: false),
                    TimeMoney = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTranss", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyTranss");
        }
    }
}
