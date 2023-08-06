using bruno.CatalogFilms.Model.View;
using System.Threading.Tasks;

namespace bruno.CatalogFilms.WebApp.MVC.Services.Interface
{
    public interface IAuthService
    {
        Task<UserResponseLogin> Login(UserLogin userLogin);

        Task<UserResponseLogin> Register(UserRegister userRegister);
    }
}
