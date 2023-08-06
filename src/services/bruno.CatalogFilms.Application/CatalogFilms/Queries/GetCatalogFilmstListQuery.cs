
using bruno.CatalogFilms.Contracts.CatalogFilms;
using FluentResults;
using MediatR;

namespace bruno.CatalogFilms.Application.CatalogFilms.Queries
{
    public record GetCatalogFilmstListQuery() : IRequest<Result<List<CatalogFilmsResult>>>;
}
