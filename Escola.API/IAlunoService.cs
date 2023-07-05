using Escola.API.Model;

namespace Escola.API
{
    public interface IAlunoService
    {
        public Aluno Criar(Aluno aluno);
        public Aluno ObterPorId(int id);

    }
}
