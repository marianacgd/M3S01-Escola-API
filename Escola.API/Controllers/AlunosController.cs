using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Model;
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
        private readonly IAlunoService _alunoService;

        public AlunosController( IAlunoService alunoService)
        {
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
            try
            {   
                var alunos = _alunoService.ObterAlunos();
                IEnumerable<AlunoDTO> alunosDtos = alunos.Select(x => new AlunoDTO(x));       
                return Ok(alunosDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
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
            try
            {
                var aluno = new Aluno(alunoDTO);
                if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

                aluno = _alunoService.Atualizar(aluno, id);

                return Ok(new AlunoDTO(aluno));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
               _alunoService.DeletarAluno(id);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

            return StatusCode(204);
        }
    }
}
