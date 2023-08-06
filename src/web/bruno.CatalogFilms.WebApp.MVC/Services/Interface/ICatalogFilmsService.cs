using bruno.CatalogFilms.Model.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResponseResult = bruno.CatalogFilms.Core.ResponseResult;

namespace bruno.CatalogFilms.WebApp.MVC.Services.Interface
{
    public interface ICatalogFilmsService
    {
        Task<List<CatalogFilmsViewModel>> GetAll();
        Task<CatalogFilmsViewModel> GetById(Guid id);
        Task<ResponseResult> AddCatalogFilms(CatalogFilmsViewModel catalogFilm);
        Task<ResponseResult> UpdateCatalogFilms(CatalogFilmsViewModel catalogFilm);
        Task<ResponseResult> RemoveCatalogFilms(Guid id);
    }
}
