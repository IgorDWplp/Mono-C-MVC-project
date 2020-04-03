using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMono.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Abrv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Abrv = table.Column<string>(nullable: true),
                    MakeIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleMake_MakeIdId",
                        column: x => x.MakeIdId,
                        principalTable: "VehicleMake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 1, "bmw", "BMW" });

            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 2, "toyota", "Toyota" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MakeIdId",
                table: "Vehicle",
                column: "MakeIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleMake");
        }
    }
}
