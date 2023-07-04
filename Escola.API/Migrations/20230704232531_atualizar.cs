using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class atualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "AlunoTB");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "AlunoTB",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "AlunoTB",
                newName: "SOBRENOME");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AlunoTB",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "AlunoTB",
                newName: "GENERO");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AlunoTB",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "AlunoTB",
                newName: "DATA_NASCIMENTO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AlunoTB",
                newName: "PK_ID");

            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE",
                table: "AlunoTB",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SOBRENOME",
                table: "AlunoTB",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "AlunoTB",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "GENERO",
                table: "AlunoTB",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "AlunoTB",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<int>(
                name: "PK_ID",
                table: "AlunoTB",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTB_EMAIL",
                table: "AlunoTB",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunoTB_EMAIL",
                table: "AlunoTB");

            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "AlunoTB",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "SOBRENOME",
                table: "AlunoTB",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "AlunoTB",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "GENERO",
                table: "AlunoTB",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "AlunoTB",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DATA_NASCIMENTO",
                table: "AlunoTB",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "PK_ID",
                table: "AlunoTB",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "AlunoTB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "AlunoTB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AlunoTB",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "AlunoTB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AlunoTB",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AlunoTB",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "AlunoTB",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
