using Microsoft.EntityFrameworkCore.Migrations;

namespace Inn_Management_System.Migrations
{
    public partial class AddRoomsAndAmenitiesTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "City", "Name", "Phone", "State" },
                values: new object[] { 1, "IRBID", null, "Inn-IRBID", "096226521", "jordan" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "City", "Name", "Phone", "State" },
                values: new object[] { 2, "JERASH", null, "Inn-JERASH", "096226522", "jordan" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "City", "Name", "Phone", "State" },
                values: new object[] { 3, "UMM QAIS", null, "Inn-UMM QAIS", "096226523", "jordan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
