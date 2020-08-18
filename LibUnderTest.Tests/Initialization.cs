using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUnderTest.Tests
{
    [TestClass]
    public class Initialization
    {
        private static TestContext _context;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _context = context;
            _context.WriteLine("Assembly!");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            _context.WriteLine("This is the end!");
        }

        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            ctx.WriteLine("In this class");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _context.WriteLine("Check the output");
        }

        [TestInitialize]
        public void OnTest()
        {
            _context.WriteLine("Entering the danger zone");
        }

        [TestCleanup]
        public void OnCleanup()
        {
            _context.WriteLine("You have now left the danger zone");
        }

        [TestMethod]
        public void TestStuff()
        {
            _context.WriteLine("Wheeeeeeeeeeeeeeeee");
            Assert.IsTrue(true);
        }
    }
}
