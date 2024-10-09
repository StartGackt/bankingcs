using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalprojectbanking.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    IdCard = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: false),
                    Nuneycetegory = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberLone = table.Column<string>(type: "TEXT", nullable: false),
                    LoneMoney = table.Column<decimal>(type: "TEXT", nullable: false),
                    MoneyFirst = table.Column<int>(type: "INTEGER", nullable: false),
                    Interest = table.Column<int>(type: "INTEGER", nullable: false),
                    UserPay = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalUserPay = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPayments");
        }
    }
}
