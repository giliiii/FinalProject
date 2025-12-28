using FinalProject.IRepositories;
using FinalProject.IServices;
using FinalProject.Models;
using FinalProject.Repositories;

namespace FinalProject.Services
{
    public class CardService 
    {
        private readonly CardRepository _repository = new();
    }
}