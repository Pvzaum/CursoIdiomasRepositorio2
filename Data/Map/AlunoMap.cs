using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas2.Data.Map
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        builder.Property(x => x.CPF).HasMaxLength(200);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.HasMany(x => x.Matriculas).WithOne(a=>a.Aluno).HasForeignKey(a=>a.AlunoId);
        }

        }
    }