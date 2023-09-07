using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AutomationTests.Login.Tests
{
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public LoginTests()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
        }

        [Fact]
        public void TestLogin()
        {
            _loginPage.Login("Admin", "admin123");
            Assert.True(_loginPage.IsLoginSuccessful(), "Login failed with valid credentials.");
        }

        [Fact]
        public void TestNoUsername()
        {
            _loginPage.Login("", "some_password");
            Assert.True(_loginPage.IsUsernameErrorDisplayed(), "Username error box not displayed");
        }

        [Fact]
        public void TestNoPassword()
        {
            _loginPage.Login("some_username", "");
            Assert.True(_loginPage.IsPasswordErrorDisplayed(), "Password error box not displayed");
        }

        [Fact]
        public void TestInvalidCredentialsAlert()
        {
            _loginPage.Login("wrong_username", "wrong_password");
            Assert.True(_loginPage.IsInvalidCredentialsAlertDisplayed(), "Invalid credentials alert not displayed");
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
