using bruno.CatalogFilms.Application.CatalogFilms.Commands;
using bruno.CatalogFilms.Application.CatalogFilms.Queries;
using bruno.CatalogFilms.Contracts.CatalogFilms;
using bruno.CatalogFilms.Core.Command;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using FluentResults;
using FluentValidation.Results;
using MediatR;

namespace bruno.CatalogFilms.CatalogFilms.CatalogFilms.CatalogFilms.Handlers
{
    public class DeleteFilmsByIdQueryHandler : CommandHandler, IRequestHandler<DeleteCatalogFilmsCommand, ValidationResult>
    {
        private readonly ICatalogFilmsRepository _catalogRepository;

        public DeleteFilmsByIdQueryHandler(ICatalogFilmsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }


        public async Task<ValidationResult> Handle(DeleteCatalogFilmsCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepository.GetById(request.Id);

            catalog.Inactivate();

            return await UnitOfWork(_catalogRepository.UnitOfWork);
        }
    }
}
