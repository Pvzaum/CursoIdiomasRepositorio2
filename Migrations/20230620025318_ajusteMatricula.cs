using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoDeIdiomas2.Migrations
{
    /// <inheritdoc />
    public partial class ajusteMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Alunos_Turmas_TurmaId",
            //    table: "Alunos");

            //migrationBuilder.DropIndex(
            //    name: "IX_Alunos_TurmaId",
            //    table: "Alunos");

            //migrationBuilder.DropColumn(
            //    name: "TurmaId",
            //    table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "TurmaId",
            //    table: "Alunos",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Alunos_TurmaId",
            //    table: "Alunos",
            //    column: "TurmaId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Alunos_Turmas_TurmaId",
            //    table: "Alunos",
            //    column: "TurmaId",
            //    principalTable: "Turmas",
            //    principalColumn: "Id");
        }
    }
}
