using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EscolaDbContexto contexto) : base(contexto)
        {
          
        }

        public bool EmailJaCadastrado(string email)
            => _context.Alunos.Any(x => x.Email == email);

    }
}
