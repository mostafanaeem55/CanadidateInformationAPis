using CanadidateInformationAPis.Models;

namespace CanadidateInformationAPis.Interfaces
{
    public interface ICandidateRepository
    {
        Task<CanadidateInfo> GetCandidateByEmail(string email);
        Task AddCandidate(CanadidateInfo candidate);
        Task UpdateCandidate(CanadidateInfo candidate);
        Task SaveChangesAsync();
    }
}
