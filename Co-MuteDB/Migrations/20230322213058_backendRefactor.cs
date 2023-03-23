using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Co_MuteDB.Migrations
{
    /// <inheritdoc />
    public partial class backendRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "CarPools",
                newName: "DepartureOrigin");

            migrationBuilder.RenameColumn(
                name: "Onwer",
                table: "CarPools",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "DaysAvailable",
                table: "CarPools",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AvailableSeats",
                table: "CarPools",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "CarPools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OwnerCarPools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarPoolId = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerCarPools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerCarPools_CarPools_CarPoolId",
                        column: x => x.CarPoolId,
                        principalTable: "CarPools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerCarPools_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPools_UserId",
                table: "CarPools",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerCarPools_CarPoolId",
                table: "OwnerCarPools",
                column: "CarPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerCarPools_UserId",
                table: "OwnerCarPools",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPools_Users_UserId",
                table: "CarPools",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPools_Users_UserId",
                table: "CarPools");

            migrationBuilder.DropTable(
                name: "OwnerCarPools");

            migrationBuilder.DropIndex(
                name: "IX_CarPools_UserId",
                table: "CarPools");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "CarPools");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CarPools",
                newName: "Onwer");

            migrationBuilder.RenameColumn(
                name: "DepartureOrigin",
                table: "CarPools",
                newName: "Origin");

            migrationBuilder.AlterColumn<string>(
                name: "DaysAvailable",
                table: "CarPools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AvailableSeats",
                table: "CarPools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
