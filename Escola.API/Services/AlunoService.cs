using Escola.API.DataBase;
using Escola.API.Exceptions;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly EscolaDbContexto _context;

        public AlunoService(EscolaDbContexto contexto)
        {
            _context = contexto;
        }

        public Aluno Criar(Aluno aluno)
        {
            var alunoExist = _context.Alunos.Any(x => x.Email == aluno.Email);
            if (alunoExist)
            {
                throw new RegistroDuplicadoException("email já cadastrado");
            }

            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public Aluno ObterPorId(int id)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);

            if (aluno == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }
            return aluno;
        }

        public List<Aluno> ObterAlunos() => _context.Alunos.ToList();

        public Aluno Atualizar(Aluno aluno, int id)
        {
            var alunoDB = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (alunoDB == null) throw new NotFoundException("Aluno não encontrado");

            alunoDB.Update(aluno);
            _context.Alunos.Update(alunoDB);
            _context.SaveChanges();
            return alunoDB;
        }

        public void DeletarAluno(int id)
        {
            var alunoDelete = _context.Alunos.Find(id);

            if (alunoDelete == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }

            _context.Alunos.Remove(alunoDelete);
            _context.SaveChanges();
        }
    }
}
