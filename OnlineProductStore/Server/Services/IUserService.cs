using OnlineProductStore.Server.DTO;

namespace OnlineProductStore.Server.Services
{
    public interface IUserService
    {
        Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDTO userRegistration);

        bool CheckIsUniqueEmail(string email);

        Task<(bool IsLoginSuccess, JWTTokenResponseDTO TokeResponse)> LoginAsync(LoginDTO loginPayload);
    }
}
