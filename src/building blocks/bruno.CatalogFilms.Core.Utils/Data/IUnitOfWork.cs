using System.Threading.Tasks;

namespace bruno.CatalogFilms.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}