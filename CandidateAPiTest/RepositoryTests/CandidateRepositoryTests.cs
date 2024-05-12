using CanadidateInformationAPis.Data;
using CanadidateInformationAPis.Models;
using CanadidateInformationAPis.Repository;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPiTest.RepositoryTests
{
    public class CandidateRepositoryTests
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;

        public CandidateRepositoryTests()
        {
            // Configure the in-memory database
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryCandidateDb")
                .Options;

            // Seed the database
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        [Fact]
        public async Task AddCandidate_AddsNewCandidate()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                var repository = new CanadidateRepository(context);
                var candidate = new CanadidateInfo { Email = "new@example.com", FirstName = "Test", LastName = "User", Comment = "Test Comment" };

                await repository.AddCandidate(candidate);
                await context.SaveChangesAsync();

                Assert.Equal(1, await context.canadidateInfos.CountAsync());
                Assert.Contains(await context.canadidateInfos.ToListAsync(), x => x.Email == "new@example.com");
            }
        }

        [Fact]
        public async Task GetCandidateByEmail_ReturnsCandidate()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                var repository = new CanadidateRepository(context);
                var candidate = new CanadidateInfo { Email = "test@example.com", FirstName = "Test", LastName = "User", Comment = "Test Comment" };
                context.canadidateInfos.Add(candidate);
                await context.SaveChangesAsync();

                var result = await repository.GetCandidateByEmail("test@example.com");

                Assert.NotNull(result);
                Assert.Equal("test@example.com", result.Email);
            }
        }
    }
}
