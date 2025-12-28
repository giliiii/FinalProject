using FinalProject.IRepositories;
using FinalProject.IServices;
using FinalProject.Models;
using FinalProject.Repositories;

namespace FinalProject.Services
{
    public class GiftService 
    {
        private readonly GiftRepository _repository = new();
    }
}