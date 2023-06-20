using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas2.Data.Map
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        
    public void Configure(EntityTypeBuilder<Matricula> builder)
        {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Numero).IsRequired().HasMaxLength(200);
            builder.HasOne(m => m.Turma).WithMany(t => t.Matriculas);

        }
    }
}
