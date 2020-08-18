using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUnderTest.Tests
{
    [TestClass]
    public class Mocking
    {
        private readonly Mock<IStringGetter> _getterMock;

        // Using Moq
        public Mocking()
        {
            _getterMock = new Mock<IStringGetter>();
        }


        [TestMethod]
        public void MethodUnderTest_GetterReturnsNull_ReturnsStringWith7Init()
        {
            // You don't have to put these comments obviously but this is the usual
            // pattern you'll see in unit testing (and other testing as well)
            //Arrange
            //Setup the _get
            _getterMock.Setup(x => x.GetString())
                .Returns<string>(null);
            var underTest = new DependencyInjection_EasyToTestSingleton(_getterMock.Object);

            //Act
            var res = underTest.MethodUnderTest();

            //Assert
            StringAssert.Contains(res, "7");
        }


        [TestMethod]
        public void MethodUnderTest_GetterReturnsEmpty_ReturnsStringWith7Init()
        {
            //Arrange
            _getterMock.Setup(x => x.GetString())
                .Returns("");
            
            var underTest = new DependencyInjection_EasyToTestSingleton(_getterMock.Object);

            //Act
            var res = underTest.MethodUnderTest();

            //Assert
            StringAssert.Contains(res, "7");
        }



    }
}
