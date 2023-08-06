using bruno.CatalogFilms.Core.Command;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using FluentValidation.Results;
using MediatR;

namespace bruno.CatalogFilms.Application.CatalogFilms.Commands.Handlers
{
    public class UpdateCatalogFilmsCommandHandler : CommandHandler, IRequestHandler<UpdateCatalogFilmsCommand, ValidationResult>
    {
        private readonly ICatalogFilmsRepository _catalogRepository;

        public UpdateCatalogFilmsCommandHandler(ICatalogFilmsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }


        public async Task<ValidationResult> Handle(UpdateCatalogFilmsCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogRepository.GetById(request.Id);

            if (catalog is null)
            {
                AddError($"Catalog Filme {request.Id} does not exist");
                return ValidationResult;
            }

            catalog.Update(request.Name, request.Description, request.Rating, request.Producer, request.Image,
                                      request.Year, request.UserId);

            return await UnitOfWork(_catalogRepository.UnitOfWork);
        }
    }
}
