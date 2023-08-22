using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioTecnico.Migrations
{
    public partial class updatedatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.RenameColumn(
                name: "placa",
                table: "RegistroMovimento",
                newName: "Placa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "RegistroMovimento",
                newName: "placa");

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Placa);
                });
        }
    }
}
