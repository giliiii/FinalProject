using BsdFinalProject.DTOs;
using BsdFinalProject.Models;

namespace BsdFinalProject.IServices
{
    public interface IUserService
    {
        abstract bool VerifyPassword(string hashedPassword, string password);
        Task<(bool Success, string? Token, string? Error)> LoginAsync(LoginDto dto);
        Task<(bool Success, string? Token, string? Error)> UserRegister(CreateUserDto dto);
        Task<User?> GetUserById(int userId);
    }
}