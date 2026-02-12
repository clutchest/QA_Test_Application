using Microsoft.Playwright;
using TestAssignment.Pages;

namespace TestAssignment.Tests
{
    internal class RegisterTests : PageTest
    {
        private LoginPage _loginPage;
        private RegisterPage _registerPage;
        private DashboardPage _dashboardPage;
        private BasePage _basePage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(Page);
            _registerPage = new RegisterPage(Page);
            _dashboardPage = new DashboardPage(Page);
            _basePage = new BasePage(Page);
        }

        [Test]
        public async Task TC01_Registration_Successful()
        {
            RegistrationData user = TestData.Generate();
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            await _registerPage.TermsCheckbox.CheckAsync();
            await _registerPage.TermsCheckbox.IsCheckedAsync();

            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(_registerPage.RegisterMessage).ToBeVisibleAsync();
            await Expect(_registerPage.RegisterMessage).ToHaveTextAsync("Registration successful! Redirecting to login...");

            await _loginPage.VerifyRegisteredUserLoginPageDisplayed();
            await _loginPage.VerifyEmptyLoginForm();

            await _loginPage.Email.FillAsync(user.Email);
            await _loginPage.Password.FillAsync(user.Password);

            await Expect(_loginPage.Email).ToHaveValueAsync(user.Email);
            await Expect(_loginPage.Password).ToHaveValueAsync(user.Password);

            await _loginPage.LoginButton.ClickAsync();

            await Expect(_loginPage.LoginMessage).ToHaveTextAsync("Login successful! Redirecting...");
            await Expect(Page).ToHaveURLAsync(new Regex(_basePage.DashboardUrl + @"(\?.*)?$"));
            await Expect(_dashboardPage.Heading).ToHaveTextAsync("Dashboard");
            await Expect(_dashboardPage.WelcomeMessage).ToContainTextAsync("Welcome, " + user.FirstName);
        }

        [Test]
        public async Task TC02_Registration_VerifyEmptyFormOnLanding()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();
        }

        [Test]
        public async Task TC03_Registration_UserAlreadyRegistered()
        {
            RegistrationData user = TestData.Generate();
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            await Expect(_registerPage.TermsCheckbox).Not.ToBeCheckedAsync();

            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync();
            await Expect(_registerPage.RegisterMessage).Not.ToHaveTextAsync("Registration successful! Redirecting to login...");

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await Expect(_loginPage.CreateNewAccountLink).ToBeVisibleAsync();
            await Expect(_loginPage.CreateNewAccountLink).ToBeEnabledAsync();

            await _loginPage.CreateNewAccountLink.ClickAsync();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            await _registerPage.CreateAccountButton.ClickAsync();
            await Expect(_registerPage.RegisterMessage).ToHaveTextAsync("User with this email already exists");
        }


        [Test]
        public async Task TC04_Registration_Failed_TermsAndConditionsNotChecked()
        {
            RegistrationData user = TestData.Generate();

            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await _registerPage.VerifyEmptyRegistrationForm();
            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            await Expect(_registerPage.TermsCheckbox).Not.ToBeCheckedAsync();

            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(_registerPage.RegisterMessage).ToBeVisibleAsync(new() { Timeout = 10000 });

            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync();
            await Expect(_registerPage.RegisterMessage).Not.ToHaveTextAsync("Registration successful! Redirecting to login...");

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
        }

        [Test]
        public async Task TC05_Registration_Failed_InvalidEmailFormat()
        {
            RegistrationData user = TestData.Generate();

            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            string invalidEmail = "invalid-email@";
            await _registerPage.Email.FillAsync(invalidEmail);

            await Expect(_registerPage.Email).ToHaveValueAsync(invalidEmail);

            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 10000 });
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await Expect(_registerPage.EmailErrorMessage).ToBeVisibleAsync();
            await Expect(_registerPage.EmailErrorMessage).ToContainTextAsync("Invalid email address");
        }

        [Test]
        public async Task TC06_Registration_Failed_PasswordsDoNotMatch()
        {
            RegistrationData user = TestData.Generate();

            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            string wrongConfirm = "Wrong" + user.Password;
            await _registerPage.ConfirmPassword.FillAsync(wrongConfirm);

            await Expect(_registerPage.ConfirmPassword).ToHaveValueAsync(wrongConfirm);
            await Expect(_registerPage.Password).Not.ToHaveValueAsync(wrongConfirm);

            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync();
            await Expect(_registerPage.RegisterMessage).Not.ToHaveTextAsync("Registration successful! Redirecting to login...", new() { Timeout = 10000 });
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
        }

        [Test]
        public async Task TC07_Registration_Failed_PasswordTooShort()
        {
            RegistrationData user = TestData.Generate();

            await _registerPage.GoTo();
            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.VerifyFields_RandomUserRegistration(user);

            await _registerPage.Password.FillAsync("123");
            await _registerPage.ConfirmPassword.FillAsync("123");

            await _registerPage.TermsCheckbox.CheckAsync();
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.PasswordErrorMessage).ToBeVisibleAsync();
            await Expect(_registerPage.PasswordErrorMessage).ToHaveTextAsync("Password must be at least 4 characters");
        }

        [Test]
        public async Task TC08_Registration_Failed_ConfirmPasswordEmpty()
        {
            RegistrationData user = TestData.Generate();

            await _registerPage.GoTo();
            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.ConfirmPassword.FillAsync("");

            await _registerPage.TermsCheckbox.CheckAsync();
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 10000 });
            await Expect(_registerPage.Heading).ToBeVisibleAsync();
        }

        [Test]
        public async Task TC09_Registration_AlreadyHaveAnAccountLink()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await Expect(_registerPage.AlreadyHaveAnAccountLink).ToBeVisibleAsync();
            await Expect(_registerPage.AlreadyHaveAnAccountLink).ToBeEnabledAsync();
            await Expect(_registerPage.AlreadyHaveAnAccountLink).ToHaveTextAsync("Already have an account? Login");

            await _registerPage.AlreadyHaveAnAccountLink.ClickAsync();
            await Expect(Page).ToHaveURLAsync(_basePage.LoginUrl);
        }

        [Test]
        public async Task TC10_Registration_Failed_AllFieldsEmpty()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 10000 });
            await Expect(_registerPage.Heading).ToBeVisibleAsync();
        }
    }
}
