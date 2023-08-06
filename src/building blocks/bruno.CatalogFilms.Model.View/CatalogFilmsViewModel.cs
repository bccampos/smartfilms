using System;
using System.ComponentModel.DataAnnotations;

namespace bruno.CatalogFilms.Model.View
{
    public class CatalogFilmsViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Field Rating is required")]
        public decimal Rating { get; set; }
        [Required(ErrorMessage = "Field Producer is required")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Field Image is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Field Year is required")]
        public int Year { get; set; }
        public Guid UserId { get; set; }
    }
}