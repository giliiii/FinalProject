//using BsdFinalProject.IRepositories;
//using BsdFinalProject.IServices;
using BsdFinalProject.DTOs;
using BsdFinalProject.IServices;
using BsdFinalProject.Models;
using BsdFinalProject.Repositories;

namespace BsdFinalProject.Services
{
    public class DonorService : IDonorService
    {
        private readonly DonorRepository _repository = new();

        public async Task<DonorDto?> GetDonorById(int id)
        {
            var d = await _repository.GetDonorById(id);
            if (d == null) return null;
            return new DonorDto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.EMail,
            };
        }


        public async Task<DonorDto?> CreateNewDonor(CreateDonorDto donorDto)
        {
            var donor = new Donor
            {
                Name = donorDto.Name,
                EMail = donorDto.Email,
                GiftsList = new List<Gift>()
            };
            var exist = await _repository.GetDonorByEmail(donor.EMail);
            if (exist != null)
                throw new Exception("Donor with this email already exists.");
            var d = await _repository.CreateNewDonor(donor);
            if (d == null) return null;
            return new DonorDto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.EMail
            };
        }

        public async Task<DonorDto?> UpdateDonor(DonorDto donorDto)
        {
            Donor donor = new Donor
            {
                Id = donorDto.Id,
                Name = donorDto.Name,
                EMail = donorDto.Email,
            };
            var d = await _repository.UpdateDonor(donor);
            if (d == null) return null;
            return new DonorDto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.EMail
            };
        }

        public async Task<IEnumerable<DonorDto>> GetAllDonors()
        {
            var donors = await _repository.GetAllDonors();
            return donors.Select(d => new DonorDto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.EMail,
            }).ToList();
        }

        public async Task<DonorDto?> DeleteDonor(int id)
        {
            var d = await _repository.DeleteDonor(id);
            if (d == null) return null;
            return new DonorDto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.EMail,
            };
        }
        public async Task<IEnumerable<GiftDto>> GetDonorGiftList(int id)
        {
            var gifts = await _repository.GetDonorGiftList(id);
            return gifts.Select(g => new GiftDto
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Cost = g.Cost,
                Picture = g.Picture,
                CategoryId = g.CategoryId,
                DonorId = g.DonorId,
                WinnerName = g.WinnerName
            }).ToList();
        }
    }
}