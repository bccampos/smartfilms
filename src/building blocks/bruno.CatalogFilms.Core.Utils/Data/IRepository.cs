using System;
using bruno.CatalogFilms.Core.DomainObjects;

namespace bruno.CatalogFilms.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; set; }
    }
}