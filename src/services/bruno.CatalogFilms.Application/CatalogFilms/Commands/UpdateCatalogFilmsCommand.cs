using bruno.CatalogFilms.Core.Command;
using bruno.CatalogFilms.Domain.Common.Enums;

namespace bruno.CatalogFilms.Application.CatalogFilms.Commands
{
    public class UpdateCatalogFilmsCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Rating { get; private set; }
        public string Producer { get; private set; }
        public string Image { get; private set; }
        public int Year { get; private set; }
        public Guid UserId { get; private set; }

        public UpdateCatalogFilmsCommand(Guid id, string name, string description, decimal rating, string producer, string image, int year, Guid userId)
        {
            Id = id;
            Name = name;
            Description = description;
            Rating = rating;
            Producer = producer;
            Image = image;
            Year = year;
            UserId = userId;
        }
    }
}
