using System.IdentityModel.Tokens.Jwt;
using CRUD_LOGIN.Dtos;
namespace CRUD_LOGIN.Services

{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);
    }
}
