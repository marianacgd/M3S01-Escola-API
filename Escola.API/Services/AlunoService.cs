﻿using Escola.API.DataBase;
using Escola.API.Exceptions;
using Escola.API.Interfaces;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.Services
{
    public class AlunoService : IAlunoService
    {
       
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno Criar(Aluno aluno)
        {
            var alunoExist = _alunoRepository.EmailJaCadastrado(aluno.Email);
            if (alunoExist)
            {
                throw new RegistroDuplicadoException("email já cadastrado");
            }

            _alunoRepository.Inserir(aluno);
            return aluno;
        }

        public Aluno ObterPorId(int id)
        {
            Aluno aluno = _alunoRepository.ObterPorId(id);

            if (aluno == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }
            return aluno;
        }

        public List<Aluno> ObterAlunos() => _alunoRepository.ObterTodos();

        public Aluno Atualizar(Aluno aluno)
        {
            var alunoDB = _alunoRepository.Atualizar(aluno);
            if (alunoDB == null) throw new NotFoundException("Aluno não encontrado");

            alunoDB.Update(aluno);
           //
            return alunoDB;
        }

        public void DeletarAluno(int id)
        {
            var alunoDelete = _alunoRepository.ObterPorId(id);

            if (alunoDelete == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }

            _alunoRepository.Excluir(id);
        }
    }
}
