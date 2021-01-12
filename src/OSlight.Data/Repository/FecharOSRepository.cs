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
    public class FecharOSRepository : Repository<FecharOS>, IFecharOSRepository
    {
        public FecharOSRepository(AppDbContext context) : base(context) { }
        
        public async Task<FecharOS> ObterChamado(Guid id)
        {
            return await Db.fecharOs.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
