using FinalProject.Data;
using FinalProject.IRepositories;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class UserRepository 
    {
        SaleContext _context = SaleContectFactory.CreateContext();
    }
}