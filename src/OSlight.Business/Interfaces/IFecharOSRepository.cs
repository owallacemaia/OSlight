using OSlight.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSlight.Business.Interfaces
{
    public interface IFecharOSRepository : IRepository<FecharOS>
    {
        Task<FecharOS> ObterFinalChamado(Guid id);
        Task<IEnumerable<FecharOS>> ObterTodosChamados();
    }
}
