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
        public async Task TC01_Registration_FirstNameRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.FirstName.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "FirstName field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC02_Registration_LastNameRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.LastName.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "LastName field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC03_Registration_EmailRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.Email.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "Email field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC04_Registration_PhoneRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.PhoneNumber.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "PhoneNumber field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC05_Registration_StreetAddressRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.StreetAddress.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "StreetAddress field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC06_Registration_CityRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.City.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "City field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC07_Registration_ZIPCodeRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.ZIPCode.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "ZIPCode field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC08_Registration_PasswordRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.ConfirmPassword.FillAsync("dummy");
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.Password.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "Password field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC09_Registration_ConfirmPasswordRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.TermsCheckbox.CheckAsync();
            await Expect(_registerPage.TermsCheckbox).ToBeCheckedAsync();

            bool isInvalid = await _registerPage.ConfirmPassword.EvaluateAsync<bool>(
                "el => !el.validity.valid && el.validity.valueMissing");
            Assert.That(isInvalid, Is.True, "ConfirmPassword field is invalid (empty + required)");

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC10_Registration_TermsCheckboxRequired()
        {
            await _registerPage.GoTo();
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");
            await _registerPage.VerifyEmptyRegistrationForm();

            var user = TestData.Generate();
            await _registerPage.FirstName.FillAsync(user.FirstName);
            await _registerPage.LastName.FillAsync(user.LastName);
            await _registerPage.Email.FillAsync(user.Email);
            await _registerPage.PhoneNumber.FillAsync(user.Phone);
            await _registerPage.StreetAddress.FillAsync(user.StreetAddress);
            await _registerPage.City.FillAsync(user.City);
            await _registerPage.ZIPCode.FillAsync(user.ZipCode);
            await _registerPage.Password.FillAsync(user.Password);
            await _registerPage.ConfirmPassword.FillAsync(user.Password);

            string originalUrl = Page.Url;
            await _registerPage.CreateAccountButton.ClickAsync();

            await Expect(Page).ToHaveURLAsync(originalUrl);
            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 8000 });
            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        [Test]
        public async Task TC11_Registration_Successful()
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
        public async Task TC12_Registration_UserAlreadyRegistered()
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
        public async Task TC13_Registration_Failed_TermsAndConditionsNotChecked()
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

            //bad practice, getting false positive results without this
            await Task.Delay(5000);

            await Expect(Page).Not.ToHaveURLAsync(_basePage.LoginUrl, new() { Timeout = 5000 });
            await Expect(Page).Not.ToHaveURLAsync(new Regex(_basePage.DashboardUrl + @"(\?.*)?$"), new() { Timeout = 5000 });
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl, new() { Timeout = 10000 });
        }

        [Test]
        public async Task TC14_Registration_Failed_InvalidEmailFormat()
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

            //bad practice, getting false positive results without this
            await Task.Delay(5000);

            await Expect(_registerPage.RegisterMessage).Not.ToBeVisibleAsync(new() { Timeout = 10000 });
            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToHaveTextAsync("Create Account");

            await Expect(_registerPage.EmailErrorMessage).ToBeVisibleAsync();
            await Expect(_registerPage.EmailErrorMessage).ToContainTextAsync("Invalid email address");
        }

        [Test]
        public async Task TC15_Registration_Failed_PasswordsDoNotMatch()
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

            //bad practice, getting false positive results without this
            await Task.Delay(5000);

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
        }

        [Test]
        public async Task TC16_Registration_Failed_PasswordTooShort()
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
        public async Task TC17_Registration_Failed_ConfirmPasswordEmpty()
        {
            RegistrationData user = TestData.Generate();

            await _registerPage.GoTo();
            await _registerPage.VerifyEmptyRegistrationForm();

            await _registerPage.PopulateFields_RandomUserRegistration(user);
            await _registerPage.ConfirmPassword.FillAsync("");

            await _registerPage.TermsCheckbox.CheckAsync();
            await _registerPage.CreateAccountButton.ClickAsync();

            bool isInvalid = await _registerPage.ConfirmPassword.EvaluateAsync<bool>(
            "el => !el.validity.valid && el.validity.valueMissing");

            Assert.That(isInvalid, Is.True, "ConfirmPassword field is invalid (empty + required)");

            await Expect(Page).ToHaveURLAsync(_basePage.RegisterUrl);
            await Expect(_registerPage.Heading).ToBeVisibleAsync();
        }

        [Test]
        public async Task TC18_Registration_AlreadyHaveAnAccountLink()
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
    }
}
