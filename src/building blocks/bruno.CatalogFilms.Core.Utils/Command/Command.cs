using System;
using FluentValidation.Results;
using MediatR;

namespace bruno.CatalogFilms.Core.Command
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}