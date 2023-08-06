using bruno.CatalogFilms.Core.Data;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using bruno.CatalogFilms.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bruno.CatalogFilms.Infrastructure.Persistence
{
    public class CatalogFilmsRepository : ICatalogFilmsRepository
    {
        private readonly CatalogFilmsDbContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
            set => throw new NotImplementedException();
        }

        public CatalogFilmsRepository(CatalogFilmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.CatalogFilms>> GetAll()
        {
            return await _context.CatalogFilms.AsNoTracking().Where(x => x.Status == Domain.Common.Enums.Status.Active).ToListAsync(); 
        }

        public async Task<Domain.CatalogFilms> GetById(Guid id)
        {
            return await _context.CatalogFilms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Domain.CatalogFilms catalogFilms)
        {
            _context.CatalogFilms.Add(catalogFilms);
        }

        public void Update(Domain.CatalogFilms catalogFilms)
        {
            _context.CatalogFilms.Update(catalogFilms);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
