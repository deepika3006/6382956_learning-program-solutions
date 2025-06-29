using NUnit.Framework;
using Moq;
using EmailApp;

namespace EmailApp.Tests
{
    public class NotificationServiceTests
    {
        private Mock<IEmailService> _mockEmailService;
        private NotificationService _notificationService;

        [SetUp]
        public void Setup()
        {
            _mockEmailService = new Mock<IEmailService>();
            _notificationService = new NotificationService(_mockEmailService.Object);
        }

        [Test]
        public void NotifyUser_ShouldReturnTrue_WhenEmailIsSentSuccessfully()
        {
            // Arrange
            _mockEmailService
                .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Act
            var result = _notificationService.NotifyUser();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NotifyUser_ShouldReturnFalse_WhenEmailFailsToSend()
        {
            // Arrange
            _mockEmailService
                .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            // Act
            var result = _notificationService.NotifyUser();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void NotifyUser_ShouldCallSendEmail_Once()
        {
            // Arrange
            _mockEmailService
                .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Act
            _notificationService.NotifyUser();

            // Assert
            _mockEmailService.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void NotifyUser_ShouldCallSendEmail_WithCorrectArguments()
        {
            // Arrange
            string expectedEmail = "user@example.com";
            string expectedMessage = "Transaction successful!";

            _mockEmailService
                .Setup(x => x.SendEmail(expectedEmail, expectedMessage))
                .Returns(true);

            // Act
            _notificationService.NotifyUser();

            // Assert
            _mockEmailService.Verify(x => x.SendEmail(expectedEmail, expectedMessage), Times.Once);
        }
    }
}
