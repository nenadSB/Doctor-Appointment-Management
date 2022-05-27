using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDocApp.Data.Migrations
{
    public partial class MyAppMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyDocModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    PainLevel = table.Column<int>(type: "int", nullable: false),
                    JPMGnumber = table.Column<int>(type: "int", nullable: false),
                    AboutPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientNetWorth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TreatmentDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyDocModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyDocModel");
        }
    }
}
