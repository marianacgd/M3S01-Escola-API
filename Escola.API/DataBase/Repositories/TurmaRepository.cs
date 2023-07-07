using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class TurmaRepository : BaseRepository<Turma, int>, ITurmaRepository
    {
        public TurmaRepository(EscolaDbContexto contexto) : base (contexto) 
        {
       
        }

    }
}
