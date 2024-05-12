using CanadidateInformationAPis.Controllers;
using CanadidateInformationAPis.Interfaces;
using CanadidateInformationAPis.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CandidateAPiTest.ControllerTests
{
    public class CandidateControllerTests
    {
        private readonly Mock<ICandidateRepository> _mockRepo;
        private readonly CanadidateController _controller;

        public CandidateControllerTests()
        {
            _mockRepo = new Mock<ICandidateRepository>();
            _controller = new CanadidateController(_mockRepo.Object);
        }

        [Fact]
        public async Task PostCandidate_AddsNewCandidate_ReturnsCreatedAtAction()
        {
            var newCandidate = new CanadidateInfo
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Comment = "Initial entry"
            };
            _mockRepo.Setup(x => x.GetCandidateByEmail(newCandidate.Email))
                     .ReturnsAsync((CanadidateInfo)null);

            _mockRepo.Setup(x => x.AddCandidate(It.IsAny<CanadidateInfo>()))
                     .Returns(Task.CompletedTask);

            var result = await _controller.PostCandidate(newCandidate);

            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(newCandidate, actionResult.Value);
            _mockRepo.Verify(x => x.AddCandidate(It.IsAny<CanadidateInfo>()), Times.Once);
        }

        [Fact]
        public async Task PostCandidate_UpdatesExistingCandidate_ReturnsNoContent()
        {
            var existingCandidate = new CanadidateInfo
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Comment = "Updated entry"
            };
            _mockRepo.Setup(x => x.GetCandidateByEmail(existingCandidate.Email))
                      .ReturnsAsync(existingCandidate);

            _mockRepo.Setup(x => x.UpdateCandidate(It.IsAny<CanadidateInfo>()))
                  .Returns(Task.CompletedTask);

            var result = await _controller.PostCandidate(existingCandidate);

            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(existingCandidate, actionResult.Value);
            _mockRepo.Verify(x => x.UpdateCandidate(It.IsAny<CanadidateInfo>()), Times.Once);
        }
    }
}
