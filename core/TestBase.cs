using EscapeFromTarkov.core.driver;
using NUnit.Framework;

namespace EscapeFromTarkov.core
{
    [TestFixture]
    public class TestBase
    {
        protected Application Driver { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.Driver = new Application();

        }

        [TearDown]
        public void TearDown()
        {
            this.Driver.QuitDriver();
        }
    }
}
