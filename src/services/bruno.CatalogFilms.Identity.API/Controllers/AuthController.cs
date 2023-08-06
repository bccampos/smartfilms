using bruno.CatalogFilms.API.Core.Controllers;
using bruno.CatalogFilms.Identity.API.Services;
using bruno.CatalogFilms.Model.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bruno.CatalogFilms.Identity.API.Controllers
{
    [Route("api/identity")]
    public class AuthController : MainController
    {
        private readonly AuthenticationService _authenticationService;

        public AuthController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                return CustomResponse(await _authenticationService.CreateJwt(userRegister.Email));
            }

            foreach (var error in result.Errors)
            {
                AddErrorProcessing(error.Description);
            }

            return CustomResponse();

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _authenticationService.SignInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await _authenticationService.CreateJwt(userLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AddErrorProcessing("User temporarily blocked by invalid attempts");
                return CustomResponse();
            }

            AddErrorProcessing("Incorrect username or password");

            return CustomResponse();
        }
    }
}
