using Escola.API.DataBase;
using Escola.API.Model;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly EscolaDbContexto _context;

        public AlunosController(EscolaDbContexto contexto)
        {
            _context = contexto;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno )
        {
            var alunoExist =  _context.Alunos.Any(x => x.Email == aluno.Email);
            if (alunoExist)
            {
                return StatusCode(StatusCodes.Status409Conflict, "email já cadastrado");
                //return Conflict("email já existe")
            }

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Aluno> alunos = _context.Alunos.ToList();

            return Ok(alunos);
        }


        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetComId([FromRoute] int id)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);

            if (aluno == null)
            {
                return NotFound("Aluno não encontrado");
            }

            return Ok(aluno);
        }


        [HttpPut]
        [Route("/{id}")]
        public IActionResult AtualizaAluno([FromBody] Aluno aluno, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            var alunoDB = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alunoDB == null) return NotFound("Aluno não encontrada");

            alunoDB.Update(aluno);
            _context.Alunos.Update(alunoDB);
            _context.SaveChanges();
            return Ok(alunoDB);
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult Delete(int id)
        {
            var alunoDelete = _context.Alunos.Find(id);

            if(alunoDelete == null)
            {
                return NotFound("Aluno não encontrado!");
            }

            _context.Alunos.Remove(alunoDelete);
            _context.SaveChanges();

            return StatusCode(204);
        }
    }
}
