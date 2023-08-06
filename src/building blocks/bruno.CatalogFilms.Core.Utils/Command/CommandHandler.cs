using System.Threading.Tasks;
using bruno.CatalogFilms.Core.Data;
using FluentValidation.Results;

namespace bruno.CatalogFilms.Core.Command
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> UnitOfWork(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("An error occurred while persisting the data.");

            return ValidationResult;
        }
    }
}