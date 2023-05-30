using Allure.Commons;
using NUnit.Allure.Attributes;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Tests;

public class LoginTest : BaseTest
{
    [Test(Description = "Успешный логин")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("User")]
    [AllureSuite("PassedSuite")]
    [AllureSubSuite("GUI")]
    [AllureIssue("TMS-12")]
    [AllureTms("TMS-13")]
    [AllureTag("Smoke")]
    [AllureLink("https://onliner.by")]
    [Description("Более детализированное описание теста")]
    [SmokeTest]
    public void SuccessLoginTest()
    {
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        
        Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
    }
}