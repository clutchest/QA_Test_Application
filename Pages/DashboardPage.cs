using Microsoft.Playwright;
using TestAssignment;
using static Microsoft.Playwright.Assertions;

namespace TestAssignment.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IPage page) : base(page) { }

        public ILocator Heading => Page.GetByRole(AriaRole.Heading, new() { Name = "Dashboard" });
        public ILocator LogoutButton => Page.GetByRole(AriaRole.Button, new() { Name = "Logout" });
        public ILocator WelcomeMessage => Page.Locator("h2");
        public ILocator LastLogin => Page.Locator("#lastLogin");

        public async Task VerifyDashboardPageDisplayed()
        {
            await Expect(Page).ToHaveURLAsync($"**{DashboardUrl}**");
        }

        public async Task Logout() => await LogoutButton.ClickAsync();

    }
}