using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces
{
    public interface IAlunoRepository
    {
        public Aluno Inserir(Aluno aluno);
        public Aluno ObterPorId(int id);
        public Aluno Atualizar(Aluno aluno);
        public List<Aluno> ObterTodos();
        public void Excluir(Aluno id);
        public bool EmailJaCadastrado(string email);
    }
}
