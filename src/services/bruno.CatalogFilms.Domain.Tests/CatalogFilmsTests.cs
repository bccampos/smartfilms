using bruno.CatalogFilms.Domain.Common.Enums;

namespace bruno.CatalogFilms.Domain.Tests
{
    public class CatalogFilmsTests
    {
        private readonly string _name;
        private readonly string _description;
        private readonly decimal _rating;
        private readonly string _producer;
        private readonly string _image;
        private readonly int _year;
        private readonly Guid _userId;
        private readonly Status _status;

        public CatalogFilmsTests()
        {
            _name = "film_Name";
            _description = "film_Description";
            _rating = 8;  
            _producer = "film_Producer";
            _image = "film_Image";
            _year = 2023;
            _userId = Guid.NewGuid();
        }

        [Fact]
        public void CreateCatalogFilme_WithValidData_ShouldCreateSuccess()
        {
            var catalogFilms = new CatalogFilms().Create(_name, _description, _rating, _producer, _image, _year, _userId);

            Assert.Equal(_name, catalogFilms.Name);
            Assert.Equal(_description, catalogFilms.Description);
            Assert.Equal(_rating, catalogFilms.Rating);
            Assert.Equal(_producer, catalogFilms.Producer);
            Assert.Equal(_image, catalogFilms.Image);
            Assert.Equal(_year, catalogFilms.Year);
            Assert.Equal(_userId, catalogFilms.UserId);
        }

        [Fact]
        public void UpdateCatalogFilms_WithValidData_ShouldUpdateSuccess()
        {
            var nameUpdate = "film_Name_update";
            var descriptionUpdate = "film_Description_update";
            var ratingUpdate = 5;
            var producerUpdate = "film_Producer_update";
            var imageUpdate = "film_Image_update";
            var yearUpdate = 2022;
            var userIdUpdate = Guid.NewGuid();

            var catalogFilmsUpdate = new CatalogFilms().Create(_name, _description, _rating, _producer, _image, _year, _userId);

            catalogFilmsUpdate.Update(nameUpdate, descriptionUpdate, ratingUpdate, producerUpdate, imageUpdate, yearUpdate, userIdUpdate);

            Assert.Equal(nameUpdate, catalogFilmsUpdate.Name);
            Assert.Equal(descriptionUpdate, catalogFilmsUpdate.Description);
            Assert.Equal(ratingUpdate, catalogFilmsUpdate.Rating);
            Assert.Equal(producerUpdate, catalogFilmsUpdate.Producer);
            Assert.Equal(imageUpdate, catalogFilmsUpdate.Image);
            Assert.Equal(yearUpdate, catalogFilmsUpdate.Year);
            Assert.Equal(userIdUpdate, catalogFilmsUpdate.UserId);
        }

        [Fact]
        public void ActivateCatalogFilms_ShouldActivateWithSuccess()
        {
            var catalogFilms = new CatalogFilms().Create(_name, _description, _rating, _producer, _image, _year, _userId);

            catalogFilms.Activate();

            Assert.Equal(Status.Active, catalogFilms.Status);
        }

        [Fact]
        public void InactivateCatalogFilms_ShouldInactivateWithSuccess()
        {
            var catalogFilms = new CatalogFilms().Create(_name, _description, _rating, _producer, _image, _year, _userId);

            catalogFilms.Inactivate();

            Assert.Equal(Status.Inactive, catalogFilms.Status);
        }

    }
}