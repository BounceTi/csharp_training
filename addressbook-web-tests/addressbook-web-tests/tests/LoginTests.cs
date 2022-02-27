using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // Prepare
            app.Auth.Logout();

            // Action
            AccountData account = new("admin", "secret");
            app.Auth.Login(account);

            // Verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // Prepare
            app.Auth.Logout();

            // Action
            AccountData account = new("admin", "123456");
            app.Auth.Login(account);

            // Verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
