using CursoDeIdiomas2.Models;
using CursoDeIdiomas2.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoDeIdiomas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;

        public MatriculaController(IMatriculaRepositorio matriculaRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Matricula>>> BuscarTodasMatriculas()
        {
            List<Matricula> matriculas = await _matriculaRepositorio.BuscarTodasMatriculas();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> BuscarPorId(int id)
        {
            Matricula matricula = await _matriculaRepositorio.BuscarPorId(id);
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<ActionResult<Matricula>> Adicionar([FromBody] Matricula matricula)
        {
            Matricula matriculaAdicionada = await _matriculaRepositorio.Adicionar(matricula);
            return Ok(matriculaAdicionada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            Matricula matricula = await _matriculaRepositorio.BuscarPorId(id);
            if (matricula == null)
            {
                return NotFound();
            }

            await _matriculaRepositorio.Excluir(matricula);
            return NoContent();
        }
    }
}
