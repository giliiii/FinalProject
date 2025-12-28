using FinalProject.IRepositories;
using FinalProject.IServices;
using FinalProject.Models;
using FinalProject.Repositories;

namespace FinalProject.Services
{
    public class UserService 
    {
        private readonly UserRepository _repository = new();
    }
}