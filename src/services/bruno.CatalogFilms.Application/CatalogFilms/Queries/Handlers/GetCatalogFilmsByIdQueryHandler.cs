using bruno.CatalogFilms.Application.CatalogFilms.Queries;
using bruno.CatalogFilms.Contracts.CatalogFilms;
using bruno.CatalogFilms.Core.Command;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using FluentResults;
using FluentValidation.Results;
using MediatR;

namespace bruno.CatalogFilms.Application.CatalogFilms.Commands.Handlers
{
    public class GetCatalogFilmsByIdQueryHandler : IRequestHandler<GetCatalogFilmstByIdQuery, Result<CatalogFilmsResult>>
    {
        private readonly ICatalogFilmsRepository _catalogRepository;

        public GetCatalogFilmsByIdQueryHandler(ICatalogFilmsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }


        public async Task<Result<CatalogFilmsResult>> Handle(GetCatalogFilmstByIdQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepository.GetById(request.Id);

            return new CatalogFilmsResult(catalog.Id, catalog.Name, catalog.Description, catalog.Rating, catalog.Producer, catalog.Image, catalog.Year, catalog.UserId);
        }
    }
}
