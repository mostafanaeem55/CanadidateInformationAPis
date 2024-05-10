using CanadidateInformationAPis.Data;
using CanadidateInformationAPis.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace CanadidateInformationAPis
{
    public class Seeder
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.canadidateInfos.Any())
            {
                return;
            }

            var candidates = new CanadidateInfo[]
            {
                new CanadidateInfo { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890", BestCallTime = "Afternoon", LinkedInURL = "http://linkedin.com/in/johndoe", GitHubURL = "http://github.com/johndoe", Comment = "Available for new opportunities." },
                new CanadidateInfo { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321", BestCallTime = "Morning", LinkedInURL = "http://linkedin.com/in/janesmith", GitHubURL = "http://github.com/janesmith", Comment = "Interested in remote positions." }
            };

            foreach (CanadidateInfo c in candidates)
            {
                context.canadidateInfos.Add(c);
            }
            context.SaveChanges();
        }
    }
}
