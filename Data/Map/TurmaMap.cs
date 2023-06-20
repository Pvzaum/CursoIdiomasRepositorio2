using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas2.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Numero).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Descrição).HasMaxLength(200);
        builder.Property(x => x.AnoLetivo).IsRequired().HasMaxLength(4);
        }

    }
}
