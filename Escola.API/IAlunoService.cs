using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API
{
    public interface IAlunoService
    {
        public Aluno Criar(Aluno aluno);
        public Aluno ObterPorId(int id);
        public Aluno Atualizar(Aluno aluno);
        public List<Aluno> ObterAlunos();
        public void DeletarAluno(int id);
    }
}
