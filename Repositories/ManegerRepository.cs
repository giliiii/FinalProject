using FinalProject.Data;
using FinalProject.IRepositories;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class ManegerRepository 
    {
        SaleContext _context = SaleContectFactory.CreateContext();
    }
}