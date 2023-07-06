using Escola.API.DataBase;
using Escola.API.DTO;
using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaDbContexto _context;

        public AlunoRepository(EscolaDbContexto contexto)
        {
            _context = contexto;
        }
        public Aluno Atualizar(Aluno aluno)
        {
            _context.Alunos.FirstOrDefault(x => x.Id == aluno.Id);
            return aluno;
        }

        public void Excluir(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        public Aluno Inserir(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public Aluno ObterPorId(int id)
        {
            return _context.Alunos.Find(id);
        }

        public List<Aluno> ObterTodos() => _context.Alunos.ToList();

        public bool EmailJaCadastrado(string email)
            => _context.Alunos.Any(x => x.Email == email);



    }
}
