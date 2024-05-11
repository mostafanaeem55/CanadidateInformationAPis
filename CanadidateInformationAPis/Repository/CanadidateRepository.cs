using CanadidateInformationAPis.Data;
using CanadidateInformationAPis.Interfaces;
using CanadidateInformationAPis.Models;
using Microsoft.EntityFrameworkCore;

namespace CanadidateInformationAPis.Repository
{
    public class CanadidateRepository : ICandidateRepository
    {
        private readonly DataContext _context;

        public CanadidateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CanadidateInfo> GetCandidateByEmail(string email)
        {
            return await _context.canadidateInfos.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddCandidate(CanadidateInfo candidate)
        {
            await _context.canadidateInfos.AddAsync(candidate);
        }

        public Task UpdateCandidate(CanadidateInfo candidate)
        {
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
