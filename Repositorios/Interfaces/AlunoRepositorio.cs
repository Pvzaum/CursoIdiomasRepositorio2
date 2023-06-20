using CursoDeIdiomas2.Data;
using CursoDeIdiomas2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Repositorios.Interfaces
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly TurmaDBContext _dbContext;

        public AlunoRepositorio(TurmaDBContext turmaDBContext)
        {
            _dbContext = turmaDBContext;
        }

        public async Task<Aluno> BuscarPorId(int id)
        {
            return await _dbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            return await _dbContext.Alunos.ToListAsync();
        }

        public async Task<Aluno> Adicionar(Aluno aluno)
        {
            // Verificar se o CPF já existe
            bool cpfExists = await _dbContext.Alunos.AnyAsync(x => x.CPF == aluno.CPF);
            if (cpfExists)
            {
                throw new Exception($"Já existe um aluno cadastrado com o CPF: {aluno.CPF}");
            }

            // Verificar se pelo menos uma turma foi informada
            if (aluno.Matriculas == null || aluno.Matriculas.Count == 0)
            {
                throw new Exception("É necessário informar pelo menos uma turma para o aluno.");
            }

            _dbContext.Alunos.Add(aluno);
            await _dbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> Atualizar(Aluno aluno, int id)
        {
            Aluno alunoPorId = await BuscarPorId(id);
            if (alunoPorId == null)
            {
                throw new Exception($"Aluno para o ID:{id} não foi encontrado.");
            }

            // Verificar se o CPF já existe para outro aluno
            bool cpfExists = await _dbContext.Alunos.AnyAsync(x => x.CPF == aluno.CPF && x.Id != id);
            if (cpfExists)
            {
                throw new Exception($"Já existe um aluno cadastrado com o CPF: {aluno.CPF}");
            }

            alunoPorId.Nome = aluno.Nome;
            alunoPorId.Email = aluno.Email;

            _dbContext.Alunos.Update(alunoPorId);
            await _dbContext.SaveChangesAsync();
            return alunoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Aluno alunoPorId = await BuscarPorId(id);
            if (alunoPorId == null)
            {
                throw new Exception($"Aluno para o ID:{id} não foi encontrado.");
            }

            _dbContext.Alunos.Remove(alunoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> apagar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
