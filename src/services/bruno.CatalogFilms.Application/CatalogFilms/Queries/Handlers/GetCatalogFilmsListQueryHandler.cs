using bruno.CatalogFilms.Application.CatalogFilms.Queries;
using bruno.CatalogFilms.Contracts.CatalogFilms;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using FluentResults;
using MediatR;

namespace bruno.CatalogFilms.Application.CatalogFilms.Commands.Handlers
{
    public class GetCatalogFilmsListQueryHandler : IRequestHandler<GetCatalogFilmstListQuery, Result<List<CatalogFilmsResult>>>
    {
        private readonly ICatalogFilmsRepository _catalogRepository;

        public GetCatalogFilmsListQueryHandler(ICatalogFilmsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }


        public async Task<Result<List<CatalogFilmsResult>>> Handle(GetCatalogFilmstListQuery request, CancellationToken cancellationToken)
        {
            var catalogList = await _catalogRepository.GetAll();

            return Result.Ok<List<CatalogFilmsResult>>(catalogList.Select(catalog => new CatalogFilmsResult
                (catalog.Id, catalog.Name, catalog.Description, catalog.Rating, catalog.Producer, catalog.Image, catalog.Year, catalog.UserId)).ToList());
        }
    }
}
