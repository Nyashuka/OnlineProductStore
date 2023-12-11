using Microsoft.AspNetCore.Mvc;
using OnlineProductStore.Server.DTO;
using OnlineProductStore.Shared.Models;

namespace OnlineProductStore.Server.Services.Users
{
    public interface IUserService
    {
        Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDTO userRegistration);

        bool CheckIsUniqueEmail(string email);

        Task<(bool IsLoginSuccess, JWTTokenResponseDTO TokeResponse)> LoginAsync(LoginDTO loginPayload);
        List<User> GetAllUsers();
    }
}
