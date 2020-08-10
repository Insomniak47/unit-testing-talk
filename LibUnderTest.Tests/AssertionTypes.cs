using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibUnderTest.Tests
{
    [TestClass]
    public class AssertionTypes
    {
        [TestMethod]
        public void NoAssertions_NoFailures()
        {
        }

        [TestMethod]
        public void AssertTrue_IsTrue()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AssertFalse_IsFalse()
        {
            Assert.IsFalse(false);
        }
    }
}
