using bruno.CatalogFilms.Model.View;
using bruno.CatalogFilms.WebApp.MVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bruno.CatalogFilms.WebApp.MVC.Controllers
{
    public class CatalogFilmsController : MainController
    {
        private readonly ICatalogFilmsService _catalogFilmsService;

        public CatalogFilmsController(ICatalogFilmsService catalogFilmsService)
        {
            _catalogFilmsService = catalogFilmsService;
        }

        [HttpGet]
        [Route("")]
        [Route("films")]
        public async Task<IActionResult> Index()
        {
            var catalogFilmsList = await _catalogFilmsService.GetAll();

            return View(catalogFilmsList);
        }

        [HttpGet]
        [Route("films-details/{id}")]
        public async Task<IActionResult> CatalogFilmsDetails(Guid id)
        {
            var catalogFilm = await _catalogFilmsService.GetById(id);

            return View(catalogFilm);
        }

        [HttpGet]
        [Route("filmPage")]
        public async Task<IActionResult> AddCatalogFilmPage()
        {
            return View("CreateCatalogFilm");
        }

        [HttpPost]
        [Route("films/add")]
        public async Task<IActionResult> AddCatalogFilm(CatalogFilmsViewModel catalogView)
        {
            if (!ModelState.IsValid) return View("CreateCatalogFilm");

            await _catalogFilmsService.AddCatalogFilms(catalogView);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("films/update")]
        public async Task<IActionResult> UpdateCatalogFilm(CatalogFilmsViewModel catalogView)
        {
            await _catalogFilmsService.UpdateCatalogFilms(catalogView);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("films/remove")]
        public async Task<IActionResult> RemoveCatalogFilm(Guid catalogFilmId)
        {
            await _catalogFilmsService.RemoveCatalogFilms(catalogFilmId);

            return RedirectToAction("Index");
        }
    }
}
