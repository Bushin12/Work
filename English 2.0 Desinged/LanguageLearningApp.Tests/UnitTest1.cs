using Moq;
static English_2._0.MainWindow;
using System.Windows.Controls;


namespace LanguageLearningApp.Tests
{
    [TestFixture]
    public class nWindowTests MainWindows
    {
        [Test]
        public void MainWindow_InstanceNotNull()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act & Assert
            Assert.IsNotNull(MainWindow.Instance);
        }

        [Test]
        public void Autorization_SetsCurrentUserAndShowsHomePage()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var mockUser = new Mock<Users>();
            var mockFrame = new Mock<Frame>();

            mainWindow.MainFrame = mockFrame.Object;

            // Act
            mainWindow.Autorization(mockUser.Object);

            // Assert
            Assert.AreEqual(mockUser.Object, mainWindow.CurrentUser);
            mockFrame.Verify(frame => frame.Navigate(It.IsAny<HomePage>()), Times.Once);
        }

        [Test]
        public void HomeButton_Click_NavigatesToHomePage()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var mockFrame = new Mock<Frame>();

            mainWindow.MainFrame = mockFrame.Object;

            // Act
            mainWindow.HomeButton_Click(null, null);

            // Assert
            mockFrame.Verify(frame => frame.Navigate(It.IsAny<HomePage>()), Times.Once);
        }

        // Аналогичные тесты для ProfileButton_Click и SettingButton_Click
    }
}