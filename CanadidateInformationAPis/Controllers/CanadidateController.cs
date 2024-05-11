using CanadidateInformationAPis.Interfaces;
using CanadidateInformationAPis.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanadidateInformationAPis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanadidateController : Controller
    {
        private readonly ICandidateRepository candidateRepository;

        public CanadidateController(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostCandidate(CanadidateInfo candidate)
        {
            var existingCandidate = await candidateRepository.GetCandidateByEmail(candidate.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.Email = candidate.Email;
                existingCandidate.LinkedInURL = candidate.LinkedInURL;
                existingCandidate.GitHubURL = candidate.GitHubURL;
                existingCandidate.Comment = candidate.Comment;
                existingCandidate.BestCallTime = candidate.BestCallTime;
                await candidateRepository.UpdateCandidate(existingCandidate);
            }
            else
            {
                await candidateRepository.AddCandidate(candidate);
            }

            await candidateRepository.SaveChangesAsync();

            return Ok(candidate);
        }
    }
}
