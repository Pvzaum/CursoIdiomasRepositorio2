using CursoDeIdiomas2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Repositorios.Interfaces
{
    public interface IMatriculaRepositorio
    {
        Task<List<Matricula>> BuscarTodasMatriculas();
        Task<Matricula> BuscarPorId(int id);
        Task<Matricula> Adicionar(Matricula matricula);
        Task Excluir(Matricula matricula);
    }
}
