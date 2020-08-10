using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void Asserts_OfDifferingFlavours()
        {
            Assert.AreEqual(0, 1 - 1);
            Assert.IsNotNull("");
            Assert.IsNull(null);

            Assert.IsInstanceOfType(new Sibling(), typeof(Sibling));


            Assert.IsInstanceOfType(new Sibling(), typeof(Base));
        }

    }

    public class Base { }
    public class Derived : Base { }
    public class Sibling : Base { }
}
