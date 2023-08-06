
using bruno.CatalogFilms.Contracts.CatalogFilms;
using FluentResults;
using MediatR;

namespace bruno.CatalogFilms.Application.CatalogFilms.Queries
{
    public record GetCatalogFilmstByIdQuery(Guid Id) : IRequest<Result<CatalogFilmsResult>>;
}
