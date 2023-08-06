using bruno.CatalogFilms.Core.Command;

namespace bruno.CatalogFilms.Application.CatalogFilms.Commands
{
    public class DeleteCatalogFilmsCommand : Command
    {
        public Guid Id { get; private set; }

        public DeleteCatalogFilmsCommand(Guid id)
        {
            Id = id;
        }
    }
}
