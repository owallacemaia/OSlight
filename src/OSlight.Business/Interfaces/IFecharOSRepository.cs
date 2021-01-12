using OSlight.Business.Models;
using System;
using System.Threading.Tasks;

namespace OSlight.Business.Interfaces
{
    public interface IFecharOSRepository : IRepository<FecharOS>
    {
        Task<FecharOS> ObterChamado(Guid id);
    }
}
