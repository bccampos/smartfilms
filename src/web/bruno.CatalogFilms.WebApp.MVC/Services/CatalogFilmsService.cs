using bruno.CatalogFilms.Model.View;
using bruno.CatalogFilms.WebApp.MVC.Extensions;
using bruno.CatalogFilms.WebApp.MVC.Services.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ResponseResult = bruno.CatalogFilms.Core.ResponseResult;

namespace bruno.CatalogFilms.WebApp.MVC.Services
{
    public class CatalogFilmsService : Service, ICatalogFilmsService
    {
        private readonly HttpClient _httpClient;

        public CatalogFilmsService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CatalogFilmsUrl);

            _httpClient = httpClient;
        }

        public async Task<List<CatalogFilmsViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync($"/api/catalogfilms/getall");

            CustomContainErrorResponse(response);

            return await DeserializeObjectResponse<List<CatalogFilmsViewModel>>(response);
        }

        public async Task<CatalogFilmsViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/catalogfilms/getbyid/{id}");

            CustomContainErrorResponse(response);

            return await DeserializeObjectResponse<CatalogFilmsViewModel>(response);
        }

        public async Task<ResponseResult> AddCatalogFilms(CatalogFilmsViewModel catalogFilm)
        {
            var itemContent = GetContent(catalogFilm);

            var response = await _httpClient.PostAsync("/api/catalogfilms/create/", itemContent);

            if (!CustomContainErrorResponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> UpdateCatalogFilms(CatalogFilmsViewModel catalogFilm)
        {
            var itemContent = GetContent(catalogFilm);

            var response = await _httpClient.PutAsync("/api/catalogfilms/update/", itemContent);

            if (!CustomContainErrorResponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> RemoveCatalogFilms(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/catalogfilms/delete/{id}");

            if (!CustomContainErrorResponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
    }
}
