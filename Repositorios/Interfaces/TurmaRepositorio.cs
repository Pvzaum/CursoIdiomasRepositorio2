using CursoDeIdiomas2.Data;
using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Repositorios.Interfaces
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly TurmaDBContext _dbContext;

        public TurmaRepositorio(TurmaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Turma>> BuscarTodasTurmas()
        {
            return await _dbContext.Turmas.ToListAsync();
        }

        public async Task<Turma> BuscarPorId(int id)
        {
            return await _dbContext.Turmas.FindAsync(id);
        }

        public async Task<Turma> Adicionar(Turma turma)
        {
            // Verificar se a turma já possui 5 alunos
            int totalAlunos = await _dbContext.Matriculas.CountAsync(x => x.TurmaId == turma.Id);
            if (totalAlunos >= 5)
            {
                throw new Exception($"A turma já possui o máximo de 5 alunos.");
            }

            _dbContext.Turmas.Add(turma);
            await _dbContext.SaveChangesAsync();
            return turma;
        }

        public async Task Atualizar(Turma turma)
        {
            _dbContext.Entry(turma).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Excluir(Turma turma)
        {
            // Verificar se a turma possui alunos matriculados
            bool temMatriculas = await _dbContext.Matriculas.AnyAsync(x => x.TurmaId == turma.Id);
            if (temMatriculas)
            {
                throw new Exception($"Não é possível excluir a turma pois possui alunos matriculados.");
            }

            _dbContext.Turmas.Remove(turma);
            await _dbContext.SaveChangesAsync();
        }

        Task<Turma> ITurmaRepositorio.Atualizar(Turma turma)
        {
            throw new NotImplementedException();
        }
    }
}
