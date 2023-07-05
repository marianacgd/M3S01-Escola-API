using Escola.API.DataBase;
using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Model;
using Escola.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly EscolaDbContexto _context;
        private readonly IAlunoService _alunoService;

        public AlunosController(EscolaDbContexto contexto, IAlunoService alunoService)
        {
            _context = contexto;
            _alunoService = alunoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlunoDTO alunoDTO)
        {
            try
            {
                var aluno = new Aluno(alunoDTO);
                //Chamada da service
                aluno = _alunoService.Criar(aluno);

                return Ok(new AlunoDTO(aluno));
            }
            catch (RegistroDuplicadoException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
                //return Conflict("email já existe")
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Aluno> alunos = _context.Alunos.ToList();

            IEnumerable<AlunoDTO> alunosDtos = alunos.Select(x => new AlunoDTO(x));

            return Ok(alunosDtos);
        }


        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetComId([FromRoute] int id)
        {
            try
            {
                return Ok(new AlunoDTO(_alunoService.ObterPorId(id)));
            }

            catch (RegistroDuplicadoException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
                //return Conflict("email já existe")
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpPut]
        [Route("/{id}")]
        public IActionResult AtualizaAluno([FromBody] AlunoDTO alunoDTO, [FromRoute] int id)
        {
            var aluno = new Aluno(alunoDTO);
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            var alunoDB = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alunoDB == null) return NotFound("Aluno não encontrada");

            alunoDB.Update(aluno);
            _context.Alunos.Update(alunoDB);
            _context.SaveChanges();
            return Ok(new AlunoDTO(alunoDB));
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult Delete(int id)
        {
            var alunoDelete = _context.Alunos.Find(id);

            if (alunoDelete == null)
            {
                return NotFound("Aluno não encontrado!");
            }

            _context.Alunos.Remove(alunoDelete);
            _context.SaveChanges();

            return StatusCode(204);
        }
    }
}
