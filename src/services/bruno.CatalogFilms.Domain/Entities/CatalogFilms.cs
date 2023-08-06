using bruno.CatalogFilms.Core.DomainObjects;
using bruno.CatalogFilms.Domain.Common.Enums;
using bruno.CatalogFilms.Domain.Core;
using System.Diagnostics;

namespace bruno.CatalogFilms.Domain
{
    public class CatalogFilms : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Rating { get; private set; }
        public string Producer { get; private set; }
        public string Image { get; private set; }
        public int Year { get; private set; }
        public Guid UserId { get; private set; }
        public Status Status { get; set; }

        public CatalogFilms()
        {
        }

        private CatalogFilms(string name, string description, decimal rating, string producer, string image,
                  int year, Guid userId)
        {
            Name = name;
            Description = description;
            Rating = rating;
            Producer = producer;
            Image = image;
            Year = year;
            UserId = userId;

            Activate();
            Validate();
        }

        public CatalogFilms Create(string name, string description, decimal rating, string producer, string image,
                  int year, Guid userId)
        {
            return new CatalogFilms(name, description, rating, producer, image, year, userId);
        }


        public void Update(string name, string description, decimal rating, string producer, string image,
                  int year, Guid userId)
        {
            Name = name;
            Description = description;
            Rating = rating; 
            Producer = producer; 
            Image = image; 
            Year = year; 
            UserId = userId;

            Validate();
        }


        public void Activate() => Status = Status.Active;

        public void Inactivate() => Status = Status.Inactive;

        public bool Equals(CatalogFilms other)
        {
            return other != null && other.Id == Id;
        }

        public void Validate()
        {
            Validation.ValidateIfEmpty(Name, $"The field Name can't be empty");
            Validation.ValidateIfEmpty(Description, $"The field Description can't be empty");
            Validation.ValidateIfEmpty(Producer, $"The field Producer can't be empty");
            Validation.ValidateIfLesserThan(Year, 0, $"Initial Year invalid");
            Validation.ValidateIfEquals(UserId, 0, $"The field UserId can't be empty");
        }

    }
}
