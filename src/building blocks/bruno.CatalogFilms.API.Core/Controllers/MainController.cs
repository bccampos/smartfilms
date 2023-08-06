using System.Collections.Generic;
using System.Linq;
using bruno.CatalogFilms.Core;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bruno.CatalogFilms.API.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (InvalidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Message", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddErrorProcessing(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddErrorProcessing(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult resposta)
        {
            ResponseContainErrors(resposta);

            return CustomResponse();
        }

        protected bool ResponseContainErrors(ResponseResult resposta)
        {
            if (resposta == null || !resposta.Errors.Messages.Any()) return false;

            foreach (var mensagem in resposta.Errors.Messages)
            {
                AddErrorProcessing(mensagem);
            }

            return true;
        }

        protected bool InvalidOperation()
        {
            return !Erros.Any();
        }

        protected void AddErrorProcessing(string erro)
        {
            Erros.Add(erro);
        }

        protected void ClearErrorProcessing()
        {
            Erros.Clear();
        }
    }
}