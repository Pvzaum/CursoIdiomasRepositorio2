using CursoDeIdiomas2.Models;

namespace CursoDeIdiomas2.Repositorios.Interfaces
{
    //Contratos de usuario
    public interface IAlunoRepositorio
    {
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<Aluno> BuscarPorId(int id);
        Task<Aluno> Adicionar(Aluno aluno);
        Task<Aluno> Atualizar(Aluno aluno, int id);
        Task<bool> apagar(int id);

    }
}
