using bruno.CatalogFilms.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bruno.CatalogFilms.Contracts.CatalogFilms
{
    public record UpdateCatalogFilms(
        Guid Id,
        string Name,
        string Description,
        decimal Rating,
        string Producer,
        string Image,
        int Year 
        );
}
