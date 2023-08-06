using bruno.CatalogFilms.Application.CatalogFilms.Commands;
using bruno.CatalogFilms.Application.CatalogFilms.Commands.Handlers;
using bruno.CatalogFilms.Core.Data;
using bruno.CatalogFilms.Domain.Common.Enums;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using Moq;
using NSubstitute;

namespace bruno.CatalogFilms.Application.Tests
{
    public class CreateCatalogFilmsCommandHandlerTests
    {
        private readonly ICatalogFilmsRepository _catalogFilmsRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _name;
        private readonly string _description;
        private readonly decimal _rating;
        private readonly string _producer;
        private readonly string _image;
        private readonly int _year;
        private readonly Guid _userId;
        private readonly Status _status;

        public CreateCatalogFilmsCommandHandlerTests()
        {
            _catalogFilmsRepository = Substitute.For<ICatalogFilmsRepository>();

            _name = "film_Name";
            _description = "film_Description";
            _rating = 8;
            _producer = "film_Producer";
            _image = "film_Image";
            _year = 2023;
            _userId = Guid.NewGuid();
            _status = Status.Active;
        }

        [Fact]
        public async Task ShouldCreateCatalogFilmsWithSuccess()
        {
            Moq.Mock<IUnitOfWork> mock = new Moq.Mock<IUnitOfWork>();
            mock.Setup(x => x.Commit()).ReturnsAsync(true);

            _catalogFilmsRepository.UnitOfWork = mock.Object;

            var command = new CreateCatalogFilmsCommand(_name, _description, _rating, _producer, _image, _year, _userId);

            var handler = new CreateCatalogFilmsCommandHandler(_catalogFilmsRepository);

            ValidationResult response = await handler.Handle(command, CancellationToken.None);

            response.Errors.Should().NotBeNull();
            response.IsValid.Should().BeTrue();
        }
    }
}