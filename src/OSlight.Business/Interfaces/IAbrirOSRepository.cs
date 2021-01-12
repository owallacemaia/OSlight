using OSlight.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSlight.Business.Interfaces
{
    public interface IAbrirOSRepository : IRepository<AbrirOS>
    {
        Task<AbrirOS> ObterEnderecoOs(Guid id);
        Task<AbrirOS> ObterChamado(Guid id);
    }
}
