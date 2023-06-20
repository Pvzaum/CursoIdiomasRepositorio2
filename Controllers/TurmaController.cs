using CursoDeIdiomas2.Models;
using CursoDeIdiomas2.Repositorios.Interfaces;
using CursoDeIdiomas2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepositorio _turmaRepositorio;

        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turma>>> BuscarTodasTurmas()
        {
            List<Turma> turmas = await _turmaRepositorio.BuscarTodasTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> BuscarPorId(int id)
        {
            Turma turma = await _turmaRepositorio.BuscarPorId(id);
            return Ok(turma);
        }

        [HttpPost]
        public async Task<ActionResult<Turma>> Adicionar([FromBody] TurmaViewModel turma)
        {
            var turmaModel = new Turma();
            turmaModel.Nome = turma.Nome;

            Turma turmaAdicionada = await _turmaRepositorio.Adicionar(turmaModel);
            return Ok(turmaAdicionada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Turma>> Atualizar(int id, [FromBody] Turma turma)
        {
            Turma turmaAtualizada = await _turmaRepositorio.Atualizar(turma);
            return Ok(turmaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            Turma turma = await _turmaRepositorio.BuscarPorId(id);
            if (turma == null)
            {
                return NotFound();
            }

            await _turmaRepositorio.Excluir(turma);
            return NoContent();
        }
    }
}
