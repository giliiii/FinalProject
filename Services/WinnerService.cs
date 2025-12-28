using FinalProject.IRepositories;
using FinalProject.IServices;
using FinalProject.Models;
using FinalProject.Repositories;

namespace FinalProject.Services
{
    public class WinnerService 
    {
        private readonly WinnerRepository _repository = new();
    }
}