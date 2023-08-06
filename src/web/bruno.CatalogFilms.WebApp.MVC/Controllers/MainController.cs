using Microsoft.AspNetCore.Mvc;
using bruno.CatalogFilms.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bruno.CatalogFilms.Core;

namespace bruno.CatalogFilms.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ReponseContainError(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Messages.Any())
            {
                foreach (var mensagem in resposta.Errors.Messages)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}
