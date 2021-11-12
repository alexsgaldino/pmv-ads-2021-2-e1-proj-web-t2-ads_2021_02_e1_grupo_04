using Microsoft.EntityFrameworkCore.Migrations;

namespace JitResidencial.Persistence.Migrations
{
    public partial class AdicionandoIdentityreview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PrimeiroNome",
                table: "AspNetUsers",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImagemURL",
                table: "AspNetUsers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "AspNetUsers",
                newName: "PrimeiroNome");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "ImagemURL");
        }
    }
}
