using CursoDeIdiomas2.Data;
using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Repositorios.Interfaces
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly TurmaDBContext _dbContext;

        public MatriculaRepositorio(TurmaDBContext turmaDBContext)
        {
            _dbContext = turmaDBContext;
        }

        public async Task<List<Matricula>> BuscarTodasMatriculas()
        {
            return await _dbContext.Matriculas.ToListAsync();
        }

        public async Task<Matricula> BuscarPorId(int id)
        {
            return await _dbContext.Matriculas.FindAsync(id);
        }

        public async Task<Matricula> Adicionar(Matricula matricula)
        {
            // Verificar se a matrícula já existe na mesma turma
            bool matriculaExists = await _dbContext.Matriculas.AnyAsync(x => x.AlunoId == matricula.AlunoId && x.TurmaId == matricula.TurmaId);
            if (matriculaExists)
            {
                throw new Exception($"O aluno já está matriculado nesta turma.");
            }

            _dbContext.Matriculas.Add(matricula);
            await _dbContext.SaveChangesAsync();
            return matricula;
        }

        public async Task<bool> Apagar(int id)
        {
            Matricula matriculaPorId = await BuscarPorId(id);
            if (matriculaPorId == null)
            {
                throw new Exception($"Matrícula para o ID:{id} não foi encontrada.");
            }

            _dbContext.Matriculas.Remove(matriculaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task Excluir(Matricula matricula)
        {
            throw new NotImplementedException();
        }
    }
}
