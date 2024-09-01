using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalprojectbanking.Migrations
{
    /// <inheritdoc />
    public partial class UserEnercs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EditOraLones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    IdCard = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: false),
                    Username1 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname1 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone1 = table.Column<string>(type: "TEXT", nullable: false),
                    EditUsername1 = table.Column<string>(type: "TEXT", nullable: false),
                    Username2 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname2 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2 = table.Column<string>(type: "TEXT", nullable: false),
                    EditUsername2 = table.Column<string>(type: "TEXT", nullable: false),
                    Username3 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname3 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3 = table.Column<string>(type: "TEXT", nullable: false),
                    EditUsername3 = table.Column<string>(type: "TEXT", nullable: false),
                    MoneyOld = table.Column<double>(type: "REAL", nullable: false),
                    LoneMoney = table.Column<double>(type: "REAL", nullable: false),
                    NumberLone = table.Column<string>(type: "TEXT", nullable: false),
                    LoneMoney1 = table.Column<double>(type: "REAL", nullable: false),
                    TotalMoneyLone = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditOraLones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditOraLones");
        }
    }
}
