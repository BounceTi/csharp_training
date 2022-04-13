using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHEKS = true;

        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        private static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, max)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
