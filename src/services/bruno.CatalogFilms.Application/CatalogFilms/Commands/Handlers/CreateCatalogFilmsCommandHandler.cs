using bruno.CatalogFilms.Core.Command;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using FluentValidation.Results;
using MediatR;

namespace bruno.CatalogFilms.Application.CatalogFilms.Commands.Handlers
{
    public class CreateCatalogFilmsCommandHandler : CommandHandler, IRequestHandler<CreateCatalogFilmsCommand, ValidationResult>
    {
        private readonly ICatalogFilmsRepository _catalogRepository;

        public CreateCatalogFilmsCommandHandler(ICatalogFilmsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }


        public async Task<ValidationResult> Handle(CreateCatalogFilmsCommand request, CancellationToken cancellationToken)
        {
            var catalog = new Domain.CatalogFilms().Create(request.Name, request.Description, request.Rating, request.Producer, request.Image,
                                      request.Year, request.UserId);

            _catalogRepository.Add(catalog);

            return await UnitOfWork(_catalogRepository.UnitOfWork);
        }
    }
}
