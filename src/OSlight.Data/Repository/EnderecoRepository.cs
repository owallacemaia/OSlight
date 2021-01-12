using Microsoft.EntityFrameworkCore;
using OSlight.Business.Interfaces;
using OSlight.Business.Models;
using OSlight.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSlight.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext db) : base(db) { }

        public async Task<Endereco> ObterEnderecoOS(Guid osId)
        {
            return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == osId);
        }
    }
}
