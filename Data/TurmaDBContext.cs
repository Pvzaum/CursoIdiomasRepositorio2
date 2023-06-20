using CursoDeIdiomas2.Data.Map;
using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas2.Data
{
    public class TurmaDBContext :DbContext
    {
        public TurmaDBContext(DbContextOptions<TurmaDBContext> options)
            : base(options) 
        {
        }
        public DbSet<Aluno> Alunos { get; set; }    
        public DbSet<Turma> Turmas { get; set; }    
        public DbSet<Matricula> Matriculas { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatriculaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
