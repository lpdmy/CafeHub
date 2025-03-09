using CafeHub.Commons.Models;
using Microsoft.AspNetCore.Identity;

namespace CafeHub.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<IdentityResult> RegisterAsync(User user, string password);
        Task<SignInResult> LoginAsync(string email, string password);
        Task LogoutAsync();

    }
}