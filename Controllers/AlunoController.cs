using CursoDeIdiomas2.Models;
using CursoDeIdiomas2.Repositorios.Interfaces;
using CursoDeIdiomas2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)

        {
            _alunoRepositorio = alunoRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> BuscarTodosAlunos()
        {
            List<Aluno> alunos = await _alunoRepositorio.BuscarTodosAlunos();
            return Ok(alunos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> BuscarPorId(int id)
        {
            Aluno aluno = await _alunoRepositorio.BuscarPorId(id);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Cadastrar([FromBody] AlunoCadastroViewModel aluno)
        {
            var alunoModel = new Aluno();
            alunoModel.CPF = aluno.CPF;
            alunoModel.Nome = aluno.Nome;
            alunoModel.Email = aluno.Email;

            alunoModel.Matriculas = new List<Matricula>();
            alunoModel.Matriculas.Add(new Matricula() { TurmaId = aluno.IdTurma });

            Aluno alunoAdicionado = await _alunoRepositorio.Adicionar(alunoModel);

            var retorno = new AlunoViewModel();
            retorno.Id = alunoAdicionado.Id;
            retorno.Nome = alunoAdicionado.Nome;


            return Ok(retorno);
        }

    }
    }
