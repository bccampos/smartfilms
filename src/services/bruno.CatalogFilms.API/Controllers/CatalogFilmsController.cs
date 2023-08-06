using bruno.CatalogFilms.API.Core.Controllers;
using bruno.CatalogFilms.API.Core.User;
using bruno.CatalogFilms.Application.CatalogFilms.Commands;
using bruno.CatalogFilms.Application.CatalogFilms.Queries;
using bruno.CatalogFilms.Contracts.CatalogFilms;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bruno.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogFilmsController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAspNetUser _user;

        public CatalogFilmsController(IMediator mediator, IMapper mapper, IAspNetUser user)
        {
            _mediator = mediator;
            _mapper = mapper;
            _user = user;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCatalogFilms request)
        {
            var userAuthenticatedId = _user.GetUserId();

            var command = new CreateCatalogFilmsCommand(request.Name, request.Description, request.Rating, request.Producer, request.Image,
                              request.Year, userAuthenticatedId);

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCatalogFilms request)
        {
            var userAuthenticatedId = _user.GetUserId();

            var command = new UpdateCatalogFilmsCommand(request.Id, request.Name, request.Description, request.Rating, request.Producer, request.Image,
                              request.Year, userAuthenticatedId);

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteCatalogFilmsCommand(id);

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }

        [HttpGet("getById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetCatalogFilmstByIdQuery(id);

            var result = await _mediator.Send(query);

            return CustomResponse(result.Value);
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCatalogFilmstListQuery();

            var response = await _mediator.Send(query);

            return Ok(response.Value); 
        }
    }
}
