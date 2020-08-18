using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibUnderTest.Tests
{
    [TestClass]
    public class DataSetTests
    {
        [DataTestMethod]
        [DataRow(int.MinValue, int.MaxValue)]
        [DataRow(-1, int.MaxValue)]
        [DataRow(-1000, 0)]
        [DataRow(11, 12)]
        //The param values come from the DataRow attributes
        public void UsingDataRows(int first, int second)
        {
            Assert.IsTrue(first <= second);
        }
    }
}
