using Training.Dtos;
using TrainingApi.Models;

namespace Training.AuthServices
{
    public interface IUserAuthenticationServices
    {
        Task<UserLognDto> LoginAccount(RegisterUser login);
        Task<string> RegisterAdmin(RegisterUser register);
        Task<string> RegisterUser(RegisterUser register);
    }
}