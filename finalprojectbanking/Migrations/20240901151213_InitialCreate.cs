using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finalprojectbanking.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Idcard = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRegisters", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Emers",
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
                    Username2 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname2 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2 = table.Column<string>(type: "TEXT", nullable: false),
                    Username3 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname3 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3 = table.Column<string>(type: "TEXT", nullable: false),
                    MoneyOld = table.Column<double>(type: "REAL", nullable: false),
                    LoneMoney = table.Column<double>(type: "REAL", nullable: false),
                    TotalMoneyLone = table.Column<double>(type: "REAL", nullable: false),
                    NumberLone = table.Column<string>(type: "TEXT", nullable: false),
                    TimeLone = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emers", x => x.Id);
                });

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
                    MoneyOld = table.Column<decimal>(type: "TEXT", nullable: false),
                    MoneyLast = table.Column<decimal>(type: "TEXT", nullable: false),
                    MoneyTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    TimeMoney = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTranss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdLones",
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
                    Username2 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname2 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2 = table.Column<string>(type: "TEXT", nullable: false),
                    Username3 = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname3 = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3 = table.Column<string>(type: "TEXT", nullable: false),
                    MoneyOld = table.Column<double>(type: "REAL", nullable: false),
                    LoneMoney = table.Column<double>(type: "REAL", nullable: false),
                    NumberLone = table.Column<string>(type: "TEXT", nullable: false),
                    TimeLone = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LoneMoney1 = table.Column<double>(type: "REAL", nullable: false),
                    TotalMoneyLone = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdLones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    IdCard = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    User1 = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneUser1 = table.Column<string>(type: "TEXT", nullable: false),
                    User2 = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneUser2 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRegisters");

            migrationBuilder.DropTable(
                name: "EditOraLones");

            migrationBuilder.DropTable(
                name: "Emers");

            migrationBuilder.DropTable(
                name: "MoneyTranss");

            migrationBuilder.DropTable(
                name: "OrdLones");

            migrationBuilder.DropTable(
                name: "Users");
           
        }
    }
}
