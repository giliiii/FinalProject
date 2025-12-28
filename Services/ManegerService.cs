using FinalProject.IRepositories;
using FinalProject.IServices;
using FinalProject.Models;
using FinalProject.Repositories;

namespace FinalProject.Services
{
    public class ManegerService 
    {
        private readonly ManegerRepository _repository = new();
    }
}