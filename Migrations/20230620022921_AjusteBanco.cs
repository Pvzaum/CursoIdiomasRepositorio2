using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoDeIdiomas2.Migrations
{
    /// <inheritdoc />
    public partial class AjusteBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "Status",
            //    table: "Turmas",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Alunos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<int>(
            //    name: "status",
            //    table: "Alunos",
            //    type: "int",
            //    nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "status",
            //    table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "CPF",
            //    table: "Alunos",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");
        }
    }
}
