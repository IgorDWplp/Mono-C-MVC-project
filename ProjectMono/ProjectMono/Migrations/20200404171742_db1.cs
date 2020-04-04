using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMono.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 1,
                column: "Abrv",
                value: "bmw");

            migrationBuilder.UpdateData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 2,
                column: "Abrv",
                value: "Mercedes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 1,
                column: "Abrv",
                value: "Bmw");

            migrationBuilder.UpdateData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 2,
                column: "Abrv",
                value: "benz");

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Abrv", "MakeId", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 1, "CX-5", 4, "Mazda CX-5 2020", null },
                    { 2, "RX-8", 4, "Mazda RX-8", null },
                    { 3, "GX", 5, "Lexus GX", null },
                    { 4, "Supra", 3, "GR Supra", null },
                    { 5, "SL", 2, "Mercedes-Benz SL-klasa", null },
                    { 6, "BMW 4C", 1, "BMW serija 4 Coupe", null }
                });
        }
    }
}
