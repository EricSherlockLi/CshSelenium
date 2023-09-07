using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationTests.Login
    public class LoginPage : BasePage
{
    private static readonly string LoginUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
    private readonly By UsernameField = By.Name("username");
    private readonly By PasswordField = By.Name("password");
    private readonly By LoginButton = By.XPath("//button[@type='submit']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
        Driver.Navigate().GoToUrl(LoginUrl);
    }

    public void EnterUsername(string username)
    {
        EnterText(UsernameField, username);
    }

    public void EnterPassword(string password)
    {
        EnterText(PasswordField, password);
    }

    public void ClickLoginButton()
    {
        ClickElement(LoginButton);
    }

    public void Login(string username, string password)
    {
        Thread.Sleep(TimeSpan.FromSeconds(10));
        EnterUsername(username);
        EnterPassword(password);
        ClickLoginButton();
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }

    public bool IsLoginSuccessful()
    {
        var dashboardElement = Driver.FindElement(By.CssSelector("h6.oxd-text.oxd-text--h6.oxd-topbar-header-breadcrumb-module"));
        return dashboardElement.Text.Contains("Dashboard") || Driver.Url.Contains("dashboard");
    }

    public bool IsUsernameErrorDisplayed()
    {
        var errorInput = Driver.FindElement(By.CssSelector("input[name='username'].oxd-input--error"));
        return errorInput.Displayed;
    }

    public bool IsPasswordErrorDisplayed()
    {
        var errorInput = Driver.FindElement(By.CssSelector("input[name='password'].oxd-input--error"));
        return errorInput.Displayed;
    }

    public bool IsInvalidCredentialsAlertDisplayed()
    {
        var alert = Driver.FindElement(By.CssSelector("p.oxd-text.oxd-text--p"));
        return alert.Displayed;
    }
}
}
