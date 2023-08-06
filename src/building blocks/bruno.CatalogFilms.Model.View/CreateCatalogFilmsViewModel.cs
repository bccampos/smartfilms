using System.ComponentModel.DataAnnotations;

namespace bruno.CatalogFilms.Model.View
{
    public class CreateCatalogFilmsViewModel
    {
        [Required(ErrorMessage = "Field {0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        public decimal Rating { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        public int Year { get; set; }
    }
}
