
using bruno.CatalogFilms.Core.Data;

namespace bruno.CatalogFilms.Domain.Interfaces.Persistence
{
    public interface ICatalogFilmsRepository : IRepository<CatalogFilms>
    {
        Task<List<Domain.CatalogFilms>> GetAll();

        Task<Domain.CatalogFilms> GetById(Guid id);

        void Add(Domain.CatalogFilms catalogFilms);

        void Update(Domain.CatalogFilms catalogFilms);
    }
}
