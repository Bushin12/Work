using NUnit.Framework;
using Moq;
using English_2._0;

namespace LanguageLearningApp.Tests
{
    [TestFixture]
    public class MainWindowTests
    {
        [Test]
        public void Autorization_SetsCurrentUserAndShowsHomePage()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var mockUser = new Mock<Users>();

            // Act
            mainWindow.Autorization(mockUser.Object);

            // Assert
            Assert.AreEqual(mockUser.Object, mainWindow.CurrentUser);
            Assert.AreEqual(Visibility.Visible, mainWindow.Home.Visibility);
        }
    }
}