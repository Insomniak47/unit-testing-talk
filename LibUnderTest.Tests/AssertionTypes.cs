using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void SpecialAsserts()
        {
            StringAssert.Contains("wakadoo", "doo");
            StringAssert.EndsWith("stringwithlotsofstuff", "stuff");
            CollectionAssert.AreEqual(new List<int> { 1, 3, 5 }, new List<int> { 1, 3, 5 });
            CollectionAssert.AllItemsAreInstancesOfType(new List<Base> { new Derived(), new Derived() }, typeof(Derived));
            
            //Will fail!
            //CollectionAssert.AllItemsAreInstancesOfType(new List<Base> { new Derived(), new Sibling() }, typeof(Derived));
        }

        [TestMethod]
        public void MakingSureThingsFail()
        {
            //Ensuring that ctor validation is set (Really common test type)
            Assert.ThrowsException<ArgumentNullException>(() => new ExplodesOnNull(null));
        }
    }

    public class Base { }
    public class Derived : Base { }
    public class Sibling : Base { }

    public class ExplodesOnNull
    {
        private readonly string _special;

        public ExplodesOnNull(string specialString)
        {
            _special = specialString ?? throw new ArgumentNullException(nameof(specialString));
        }
    }
}
