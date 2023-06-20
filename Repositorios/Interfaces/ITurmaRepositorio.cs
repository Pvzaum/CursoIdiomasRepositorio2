using CursoDeIdiomas2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Repositorios.Interfaces
{
    public interface ITurmaRepositorio
    {
        Task<List<Turma>> BuscarTodasTurmas();
        Task<Turma> BuscarPorId(int id);
        Task<Turma> Adicionar(Turma turma);
        Task<Turma> Atualizar(Turma turma);
        Task Excluir(Turma turma);
    }
}