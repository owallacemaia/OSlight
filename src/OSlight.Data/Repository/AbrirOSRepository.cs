using Microsoft.EntityFrameworkCore;
using OSlight.Business.Interfaces;
using OSlight.Business.Models;
using OSlight.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSlight.Data.Repository
{
    public class AbrirOSRepository : Repository<AbrirOS>, IAbrirOSRepository
    {
        public AbrirOSRepository(AppDbContext db) : base(db) { }

        public async Task<AbrirOS> ObterChamado(Guid id)
        {
            return await Db.abrirOs.AsNoTracking()
                .Include(a => a.FecharOS)
                .Include(a => a.Endereco)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

     

        public async Task<AbrirOS> ObterEnderecoOs(Guid id)
        {
            return await Db.abrirOs.AsNoTracking()
                .Include(a => a.Endereco)
                .Include(a => a.FecharOS)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AbrirOS>> ObterTodosChamados()
        {
            return await Db.abrirOs.AsNoTracking()
                .Include(a => a.FecharOS)
                .Include(a => a.Endereco)
                .ToListAsync();
        }
    }
}
