using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transit.Web.Migrations
{
    public partial class CompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Owners",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Owners",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owners",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CellPhone",
                table: "Owners",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "Owners",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberLicencia = table.Column<int>(maxLength: 20, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(maxLength: 20, nullable: false),
                    DateSoatStar = table.Column<DateTime>(nullable: false),
                    DateSoatEnd = table.Column<DateTime>(nullable: false),
                    DateTecnoStar = table.Column<DateTime>(nullable: false),
                    DateTecnoEnd = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(maxLength: 20, nullable: false),
                    Vin = table.Column<string>(maxLength: 20, nullable: false),
                    TypeVehicle = table.Column<string>(maxLength: 20, nullable: false),
                    Ownerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Owners_Ownerid",
                        column: x => x.Ownerid,
                        principalTable: "Owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false),
                    Vehicleid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_VehicleImages_Vehicles_Vehicleid",
                        column: x => x.Vehicleid,
                        principalTable: "Vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_LicenseId",
                table: "Owners",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_Vehicleid",
                table: "VehicleImages",
                column: "Vehicleid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Ownerid",
                table: "Vehicles",
                column: "Ownerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Licenses_LicenseId",
                table: "Owners",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Licenses_LicenseId",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Owners_LicenseId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Owners");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Owners",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Owners",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owners",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CellPhone",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
